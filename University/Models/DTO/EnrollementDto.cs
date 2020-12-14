using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.Entities;

namespace University.Models.DTO
{
    public class EnrollementDto
    {
        public int Grade { get; set; }

        //Foregin key


        //Navigation property
        public Student Student { get; set; }
        public Course Course { get; set; }


    }
}

