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
        //public HomeViewModel(bool isAuthenticated)
        //{
        //    IsAuthenticated = isAuthenticated;
        //}ObservableCollection

        //public bool IsAuthenticated { get; private set; }

        //public IList<ActivityViewModel> Activities { get; } = new ObservableCollection<ActivityViewModel>();

        public List<ActivitySummary> Activities { get; set; }
        public Athlete Athlete { get; set; }
    }
}