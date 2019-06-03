using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customers = (Customers)validationContext.ObjectInstance;

            if (customers.MembershipTypeId == MembershipType.unknown || customers.MembershipTypeId == MembershipType.PayAsYouGo )
                return ValidationResult.Success;

            if (customers.Birthdate == null)
                return new ValidationResult("The Date of Birth field is required");

            var age = DateTime.Now.Year - customers.Birthdate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("The Customer must be at least 18yrs to go on a Membership.");
        }
    }
}