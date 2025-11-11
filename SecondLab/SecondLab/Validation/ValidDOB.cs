using SecondLab.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondLab.Validation
{
    public class ValidDOB: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectInstance as Registration;
            if (obj == null)
            {
                return new ValidationResult("Invalid object");
            }
            DateTime dob = obj.Dob;
            int age = DateTime.Now.Year - dob.Year;
            if (DateTime.Now.DayOfYear < dob.DayOfYear)
            {
                age--;
            }
            if (age < 18)
            {
                return new ValidationResult("You must be at least 18 years old.");
            }
            return ValidationResult.Success;
        }

    }
}