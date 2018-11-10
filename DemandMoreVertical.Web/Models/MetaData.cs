using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemandMoreVertical.Web.Models
{
   [MetadataType(typeof(Contact.Metadata))]
    public partial class Contact
    {
        private sealed class Metadata
        {
            public int ContactID { get; set; }
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Required]
            [EmailAddress(ErrorMessage = "Invalid Email")]
            public string Email { get; set; }
            [Required]
            public string Message { get; set; }
        }
    }

}