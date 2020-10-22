using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int Grade { get; set; }

        //Foregin key
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        //Navigation property
        public Student Student { get; set; }
        public  Course Course { get; set; }
    }
}
