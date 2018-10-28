using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemandMoreVertical.Web.Controllers
{
    public class StravaController : Controller
    {
        // GET: Strava
        public ActionResult Index()
        {

            var redirectUrl = $"{Request.Url.Scheme}://{Request.Url.Host}:{Request.Url.Port}/Home/Callback";
            return Redirect("https://www.strava.com/oauth/authorize?client_id=18876&response_type=code&scope=activity:read_all&redirect_uri=" + redirectUrl+"&approval_prompt=force");
        }
    }
}