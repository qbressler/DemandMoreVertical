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

        public ActionResult Index()
        {
            return View();
        }

    }
}