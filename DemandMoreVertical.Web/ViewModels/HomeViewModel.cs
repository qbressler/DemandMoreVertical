using StravaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace DemandMoreVertical.Web.ViewModels
{
    public class HomeViewModel
    {
        #region constructor
        public HomeViewModel()
        {
            Activities = new List<Classes.Activity>();
            Athlete = new Classes.Athlete();
        }
        #endregion

        public IList<Classes.Activity> Activities { get; set; }
        public Classes.Athlete Athlete { get; set; }
    }
}