using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Models
{
    public class Customers
    // all data anntations
    //[Required]
    //[StringLenght(number)]
    //[Range(min,max)]
    //[COmpare("otherProperty")]
    //[Phone]
    //[EmailAddress]
    //[Url]
    //[RegularExpression(...)]
    {   [Required]
        public int id { get; set; }

        [Required(ErrorMessage ="Por favor introduzca un nombre.")]
        [Display(Name = "Name")]
        public string name { get; set; }

        public bool isSubscribedToNewsLetter { get; set; }

        public MembershipType membershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte membershipTypeId { get; set; }

        [Display(Name = "Day of Birth")]
        [BiggerThan18]
        public DateTime? birthDate { get; set; }
    }
}