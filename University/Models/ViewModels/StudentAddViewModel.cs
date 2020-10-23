using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using University.Validations;

namespace University.Models.ViewModels
{
    public class StudentAddViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Remote(action:"CheckEmail", controller:"Students")]
        [EmailAddress]
        public string Email { get; set; }

        [CheckStreetNr(max: 10)]
        public string AdressStreet { get; set; }
        public string AdressCity { get; set; }
        public string AdressZipCode { get; set; }
    }
}
