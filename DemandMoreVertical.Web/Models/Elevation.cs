//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemandMoreVertical.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Elevation
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string ActivityName { get; set; }
        public string Athlete { get; set; }
        public System.DateTime ActivityDate { get; set; }
        public int ElevationGain { get; set; }
        public int ActivityID { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int ParkId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
