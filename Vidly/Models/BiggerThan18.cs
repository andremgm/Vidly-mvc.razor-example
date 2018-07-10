using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class BiggerThan18 : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;

            if (customer.membershipTypeId == MembershipType.unknown || 
                customer.membershipTypeId == MembershipType.payAsYouGo)
                return ValidationResult.Success;

            if (customer.birthDate == null)
                return new ValidationResult("Birtdate is required");


            var age = DateTime.Today.Year - customer.birthDate.Value.Year;

            if (age >= 18)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("You are too young, come back when you are 18");
            }
        }



    }
}