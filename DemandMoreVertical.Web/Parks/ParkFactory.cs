using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace DemandMoreVertical.Web.Parks
{
    /// <summary>
    /// Builds park factory...
    /// </summary>
    public static class ParkFactory
    {
        #region CVNP coords
        private const decimal CVNP_NLAT = 41.32m;
        private const decimal CVNP_SLAT = 41.16m;
        private const decimal CVNP_WLONG = -81.60m;
        private const decimal CVNP_ELONG = -81.50m;
        #endregion

        public static RunningParks Build(decimal startingLatitude, decimal startingLongitude)
        {
            RunningParks park = null;

            if (Decimal.Compare(startingLatitude, CVNP_NLAT) < 0 
                && Decimal.Compare(startingLatitude, CVNP_SLAT) > 0
                && Decimal.Compare(startingLongitude, CVNP_WLONG) > 0
                && Decimal.Compare(startingLongitude, CVNP_ELONG) < 0)
            {
                // falls inbetween the most northern and southern point of CVNP
                Debug.Write("Building CVNP Object");
                park = new CVNP("CVNP");
            }
            else
                park = new GenericPark("Generic");

            return park;
        }
    }
}