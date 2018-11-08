using DemandMoreVertical.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemandMoreVertical.Web.Parks
{
    public class CVNP : RunningParks
    {

        #region constructor
        public CVNP()             
        {
            _db = new Entities();
        }
        #endregion

        #region methods
        public override List<Elevation> GetAll()
        {
            return _db.Elevations.Where(w => w.ParkId == this.ParkID).ToList();
        }

        public override Elevation Get(int id)
        {
            return _db.Elevations.Where(w => w.Id == id).FirstOrDefault();
        }
        #endregion

        #region properties
        public override int ParkID => 1;

        public override string ParkName => "CVNP";

        private Entities _db = null;
        #endregion
    }
}