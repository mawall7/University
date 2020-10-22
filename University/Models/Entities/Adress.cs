using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models.Entities
{
    public class Adress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        //Foregin key
        public int StudentId { get; set; }

        //NavigationProperty
        public Student Student { get; set; }
    }
}
