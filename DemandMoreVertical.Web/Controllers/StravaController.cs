using DemandMoreVertical.Web.Authentication;
using DemandMoreVertical.Web.Models;
using DemandMoreVertical.Web.Parks;
using DemandMoreVertical.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using StravaSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DemandMoreVertical.Web.Controllers
{
    [Authorize]
    public class StravaController : Controller
    {
        private readonly Entities _db = null;

        public StravaController()
        {
            _db = new Entities();
        }
        // GET: Strava
        public ActionResult Index()
        {
            string redirectUrl = $"{Request.Url.Scheme}://{Request.Url.Host}:{Request.Url.Port}/Strava/CallBack";
            return Redirect("https://www.strava.com/oauth/authorize?client_id=18876&response_type=code&scope=activity:read_all&redirect_uri=" + redirectUrl+"&approval_prompt=auto");
        }

        public async Task<ActionResult> MyStats()
        {
            var authenticator = CreateAuthenticator();
            var viewModel = new MyStatsViewModel();
            DateTime beginDate = DateTime.Today;
            while (beginDate.DayOfWeek != DayOfWeek.Monday)
            {
                beginDate = beginDate.AddDays(-1);
            }
            viewModel.Monday = beginDate;
            viewModel.Sunday = beginDate.AddDays(7);

            long unixtimestampBeginDate = ConvertToUnixTime(beginDate);
            long unixtimestampEndDate = ConvertToUnixTime(beginDate.AddDays(7));
            if (authenticator.IsAuthenticated)
            {
                try
                {
                    var client = new Client(authenticator);

                    HttpClient httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authenticator.AccessToken);

                    var response = await httpClient.GetStringAsync("https://www.strava.com/api/v3/athlete");
                    var ath = JsonConvert.DeserializeObject<Classes.Athlete>(response);

                    response = await httpClient.GetStringAsync($"https://www.strava.com/api/v3/athlete/activities?after={unixtimestampBeginDate}&before={unixtimestampEndDate}");
                    //response = await httpClient.GetStringAsync($"https://www.strava.com/api/v3/athlete/activities");

                    var acts = JsonConvert.DeserializeObject<List<Classes.Activity>>(response);

                    //insert into db now.
                    foreach (var w in acts)
                    {
                        // Wetmore Trail coords
                        //w.start_latitude = 41.21m;
                        //w.start_longitude = -81.54;

                        #region determine park
                        RunningParks park = ParkFactory.Build(Convert.ToDecimal(w.start_latitude), Convert.ToDecimal(w.start_longitude));
                        Debug.WriteLine(park.ParkName);
                        #endregion
                       
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
                                    ElevationGain = Convert.ToInt32(Convert.ToInt32(w.total_elevation_gain) * 3.2808),
                                    ActivityID = Convert.ToInt32(w.id),
                                    Latitude = Convert.ToDecimal(w.start_latitude),
                                    Longitude = Convert.ToDecimal(w.start_longitude),
                                    ParkId = park.ParkID,
                                    ParkName = park.ParkName
                                }
                            );
                            _db.SaveChanges();
                        }
                    }

                    // Build ViewModel
                    string userID = User.Identity.GetUserId().ToString();
                    viewModel.Activities = _db.Elevations.Where(w=>w.UserID == userID).OrderByDescending(w=>w.ActivityDate).ToList();
                    viewModel.Athlete = ath;

                    ViewBag.Title = "Sync / My Stats";
                    return View(viewModel);
                }
                catch (Exception e)
                {
                    return HttpNotFound("An error has occured while obtaining strava data. Please contact support." + e.Message);
                }
            }
            return RedirectToAction("Index", "Strava");
        }

        Authenticator CreateAuthenticator()
        {
            string secretkey = String.Empty;
            //using (StreamReader reader = new StreamReader(@"C:\Users\qbressler\Desktop\strava_api_key.txt"))
            //{
            //    secretkey = reader.ReadToEnd();
            //}
            secretkey = ConfigurationManager.AppSettings["clientkey"];
            var redirectUrl = $"{Request.Url.Scheme}://{Request.Url.Host}:{Request.Url.Port}/Strava/Callback";
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
            return RedirectToAction("MyStats");
        }

        [System.Web.Mvc.HttpGet]
        public void GetResponse(StravaResponse body)
        {
            Response.Write(JsonConvert.SerializeObject(body));
        }
        #region Helpers
        public static long ConvertToUnixTime(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(datetime - sTime).TotalSeconds;
        }
        #endregion
    }

    public class StravaResponse
    {
        public string State { get; set; }
        public string Code { get; set; }
        public string error { get; set; }

    }
}