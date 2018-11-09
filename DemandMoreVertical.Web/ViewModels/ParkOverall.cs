using DemandMoreVertical.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemandMoreVertical.Web.ViewModels
{
    public class ParkOverall
    {
        public List<Elevation> Elevation { get; set; }
        public List<ParkTotals> ParkTotals { get; set; }
    }

    public class ParkTotals
    {
        public string Athlete { get; set; }
        public decimal TotalGain { get; set; }
    }
}