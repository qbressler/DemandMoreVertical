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
            
            RunningParks parks = new CVNP();

            var viewModel = new ParkOverall
            {
                Elevation = parks.GetAll(),
                ParkTotals = parks.GetLeaders()
            };

            return View(viewModel);
        }
    }
}