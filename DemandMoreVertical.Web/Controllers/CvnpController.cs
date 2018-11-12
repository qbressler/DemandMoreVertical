using DemandMoreVertical.Web.Parks;
using DemandMoreVertical.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemandMoreVertical.Web.Controllers
{
    public class CvnpController : Controller
    {

        // GET: Cvnp
        public ActionResult Index()
        {
            ViewBag.Title = "Cuyahoga Valley Nation Park Stats";
            RunningParks parks = new CVNP();

            var viewModel = new ParkOverall
            {
                Elevation = parks.GetAll().OrderByDescending(w=>w.ActivityDate).ToList(),
                ParkTotals = parks.GetLeaders().OrderByDescending(w => w.TotalGain).ToList()
            };

            return View(viewModel);
        }
    }
}