using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace DemandMoreVertical.Web.Parks
{
    public static class ParkFactory
    {
        public static Park Build(decimal startingLatitude)
        {
            Park park = null;
            if (Decimal.Compare(startingLatitude, 41.20m) < 0 && Decimal.Compare(startingLatitude, 41.16m) > 0)
            {
                // falls inbetween the most northern and southern point of CVNP
                Debug.Write("Building CVNP");
                park = new CVNP("CVNP");
            }
            else
                park = new GenericPark("Generic");
            return park;
        }
    }
}