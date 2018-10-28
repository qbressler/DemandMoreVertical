using DemandMoreVertical.Web.Authentication;
using DemandMoreVertical.Web.Models;
using DemandMoreVertical.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable.OAuth2;
using StravaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DemandMoreVertical.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly Entities _db = null;

        public HomeController()
        {
            _db = new Entities();
        }
        public async Task<ActionResult> Index()
        {
            var authenticator = CreateAuthenticator();
            //var viewModel = new HomeViewModel(authenticator.IsAuthenticated);
           
            if (authenticator.IsAuthenticated)
            {
                try
                {
                    var client = new StravaSharp.Client(authenticator);

                    // TESTING
                    HttpClient httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authenticator.AccessToken);

                    var response = await httpClient.GetStringAsync("https://www.strava.com/api/v3/athlete");
                    var ath = JsonConvert.DeserializeObject<Classes.Athlete>(response);

                    response = await httpClient.GetStringAsync("https://www.strava.com/api/v3/athlete/activities");
                    var acts = JsonConvert.DeserializeObject<List<Classes.Activity>>(response);

                    //insert into db now.

                    foreach (var w in acts)
                    {
                        var exists = Convert.ToBoolean(_db.Elevations.Where(x => x.ActivityID == w.id).Count());
                        if (!exists)
                        {
                            _db.Elevations.Add(
                                new Elevation
                                {
                                    ActivityDate = w.start_date,
                                    ActivityName = w.name,
                                    UserID = User.Identity.GetUserId(),
                                    Athlete = $"{ath.firstname} {ath.lastname}",
                                    ElevationGain = Convert.ToInt32(Convert.ToDouble(w.total_elevation_gain) * 3.2808),
                                    ActivityID = Convert.ToInt32(w.id)
                                }
                            );
                            _db.SaveChanges();
                        }
                    }

                    // Build ViewModel
                    var viewModel = new HomeViewModel();
                    viewModel.Activities = acts;
                    viewModel.Athlete = ath;

                    return View(viewModel);
                }
                catch(Exception e)
                {
                    return HttpNotFound("An error has occured while obtaining strava data! " +e.Message);
                }
            }
            return RedirectToAction("Index", "Strava");
        }

        Authenticator CreateAuthenticator()
        {
            string secretkey = String.Empty;
            using (StreamReader reader = new StreamReader(@"C:\Users\qbressler\Desktop\strava_api_key.txt"))
            {
                secretkey = reader.ReadToEnd();
            }
            var redirectUrl = $"{Request.Url.Scheme}://{Request.Url.Host}:{Request.Url.Port}/Home/Callback";
            var config = new RestSharp.Portable.OAuth2.Configuration.RuntimeClientConfiguration
            {
                IsEnabled = true,
                ClientId = "18876",
                ClientSecret = secretkey,
                RedirectUri = redirectUrl,
                Scope = "read_all",
               
            };
            var client = new StravaClient(new Authentication.RequestFactory(), config);

            return new Authenticator(client);
        }

        public async Task<ActionResult> List()
        {
            var authenticator = CreateAuthenticator();
            var loginUri = await authenticator.GetLoginLinkUri();

            return Redirect(loginUri.AbsoluteUri);
        }

        public async Task<ActionResult> Callback()
        {
            var authenticator = CreateAuthenticator();
            await authenticator.OnPageLoaded(Request.Url);
            return RedirectToAction("Index");
        }

    }
}