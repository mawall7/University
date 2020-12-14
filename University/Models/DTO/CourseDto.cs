using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.Entities;

namespace University.Models.DTO
{
    public class CourseDto
    {
        public string Title { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
