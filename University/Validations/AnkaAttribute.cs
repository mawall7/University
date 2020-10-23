using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using University.Models.ViewModels;

namespace University.Validations
{
    public class AnkaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            const string errormessage = "Fail";
            if (value is string s)
            {
                var studentModel = (StudentAddViewModel)validationContext.ObjectInstance;
                if (studentModel.FirstName == "Kalle" && s == "Anka")
                    return ValidationResult.Success;
                else
                    return new ValidationResult(errormessage);
            }
            return new ValidationResult(errormessage);

        }
    }
}
