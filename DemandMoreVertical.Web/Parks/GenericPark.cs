using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemandMoreVertical.Web.Parks
{
    public class GenericPark : RunningParks
    {
        public GenericPark(string parkName) : base(parkName)
        {

        }

        public override int ParkID => 2;
    }
}