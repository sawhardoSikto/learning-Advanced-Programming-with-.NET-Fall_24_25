using mid2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace mid2.Validation
{
    public class ValidEmail : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectInstance as Registration;
            if (obj == null)
            {
                return new ValidationResult("Invalid Object");
            }
            string email = obj.Email;
            string id = obj.Id;
            var emailPrefix = email.Split('@')[0];
            string pattern = @"^\d{2}-\d{5}-[1-3]@student\.aiub\.edu$";
            if (!Regex.IsMatch(email, pattern))
            {
                return new ValidationResult("Email must be in format xx-xxxxx-x@student.aiub.edu");

            }
            if(emailPrefix !=id)
            {
                return new ValidationResult("Id must match in the first part of the Email (before @)");

            }

            return ValidationResult.Success;
        }
    }
}
