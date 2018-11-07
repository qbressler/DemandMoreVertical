using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemandMoreVertical.Web.Parks
{
    public abstract class RunningParks
    {

        #region properties
        public string ParkName { get; protected set; }
        public abstract int ParkID { get; }
        #endregion

        #region constructor
        public RunningParks(string parkName)
        {
            ParkName = parkName;
        }
        #endregion

        #region methods
      
        #endregion

    }
}