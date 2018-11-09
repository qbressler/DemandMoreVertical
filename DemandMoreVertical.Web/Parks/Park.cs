using DemandMoreVertical.Web.Models;
using DemandMoreVertical.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemandMoreVertical.Web.Parks
{
    public abstract class RunningParks
    {

        #region properties
        public abstract string ParkName { get; }
        public abstract int ParkID { get; }
        #endregion

        #region constructor
        public RunningParks()
        {
            
        }
        #endregion

        #region methods
        public abstract List<Elevation> GetAll();

        public abstract Elevation Get(int id);

        public abstract List<ParkTotals> GetLeaders();
        #endregion

    }
}