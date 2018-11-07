using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemandMoreVertical.Web.Parks
{
    public class CVNP : RunningParks
    {
        public CVNP(string parkName) : base(parkName)
        {

        }

        public override int ParkID => 1;
    }
}