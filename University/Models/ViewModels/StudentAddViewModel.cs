using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models.ViewModels
{
    public class StudentAddViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AdressStreet { get; set; }
        public string AdressCity { get; set; }
        public string AdressZipCode { get; set; }
    }
}
