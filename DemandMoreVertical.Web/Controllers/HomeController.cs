using DemandMoreVertical.Web.Authentication;
using DemandMoreVertical.Web.ViewModels;
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
    public class HomeController : Controller
    {
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
                    var response = await httpClient.GetStringAsync("https://www.strava.com/api/v3/athlete/activities");

                    // Build ViewModel
                    var viewModel = new HomeViewModel();
                    viewModel.Activities = await client.Activities.GetAthleteActivities();
                    viewModel.Athlete = await client.Athletes.GetCurrent();

                    return View(viewModel);
                }
                catch(Exception e)
                {
                    return HttpNotFound("An error has occured while obtaining strava data");
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