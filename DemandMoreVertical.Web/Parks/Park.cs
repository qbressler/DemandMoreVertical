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
        public abstract List<Models.Elevation> GetAll();

        public abstract Models.Elevation Get(int id);
        #endregion

    }
}