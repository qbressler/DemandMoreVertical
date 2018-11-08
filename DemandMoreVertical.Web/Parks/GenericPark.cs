using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemandMoreVertical.Web.Models;

namespace DemandMoreVertical.Web.Parks
{
    public class GenericPark : RunningParks
    {
        public GenericPark()
        {

        }

        public override int ParkID => 2;
        public override string ParkName => "Generic";
        public override Elevation Get(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Elevation> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}