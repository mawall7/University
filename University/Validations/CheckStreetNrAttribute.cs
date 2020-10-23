using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace University.Validations
{
    public class CheckStreetNrAttribute : ValidationAttribute, IClientModelValidator
    {
        public CheckStreetNrAttribute()
        {
            
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-streetnr", "Error");
        }

        public override bool IsValid(object value)
        {
            if(value is string input)
            {
                var last = input.Split().Last();
                return int.TryParse(last, out _);
            }
            return false;
        }
    }
}
