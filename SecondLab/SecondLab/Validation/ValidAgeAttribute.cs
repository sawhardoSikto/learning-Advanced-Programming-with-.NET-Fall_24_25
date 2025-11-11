using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondLab.Validation
{
    public class ValidAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public ValidAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dob)
            {
                var age = DateTime.Today.Year - dob.Year;
                if (dob > DateTime.Today.AddYears(-age))
                    age--;

                if (age >= _minimumAge)
                    return ValidationResult.Success;
                else
                    return new ValidationResult($"Age must be at least {_minimumAge} years.");
            }
            return new ValidationResult("Invalid Date of Birth.");
        }
    }
}