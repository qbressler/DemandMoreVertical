using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemandMoreVertical.Web.Parks
{
    public class Park
    {

        #region properties
        public string ParkName { get; protected set; }
        #endregion

        #region constructor
        public Park(string parkName)
        {
            ParkName = parkName;
        }
        #endregion

        #region methods
      
        #endregion

    }
}