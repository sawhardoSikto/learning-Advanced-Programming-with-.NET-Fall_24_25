using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondLab.Validation
{
    public class IDMatchesEmailAttribute: ValidationAttribute
    {
        private readonly string _emailPropertyName;

        public IDMatchesEmailAttribute(string emailPropertyName)
        {
            _emailPropertyName = emailPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var emailProperty = validationContext.ObjectType.GetProperty(_emailPropertyName);
            if (emailProperty == null)
                return new ValidationResult($"Unknown property: {_emailPropertyName}");

            var emailValue = emailProperty.GetValue(validationContext.ObjectInstance, null) as string;
            if (value is string id && emailValue != null)
            {
                var emailPrefix = emailValue.Split('@')[0];
                if (id == emailPrefix)
                    return ValidationResult.Success;
                else
                    return new ValidationResult("ID must match the first part of the Email.");
            }
            return new ValidationResult("Invalid ID.");
        }
    }
}