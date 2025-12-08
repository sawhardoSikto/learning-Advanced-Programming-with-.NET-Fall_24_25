using PMS.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.CustomValidation
{
    public class ValidUserName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var uname = value.ToString();
                var db = new PMSEntities();
                var user = (from u in db.Customers
                            where u.Username.Equals(uname)
                            select u).SingleOrDefault(); 
                if (user == null)
                {
                    return ValidationResult.Success;
                }
                else
                {
                                       return new ValidationResult("Username already exists");
                }
            }
            return new ValidationResult("Username is required");

        }
    }
}