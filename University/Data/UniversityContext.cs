using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Models.Entities;

namespace University.Data
{
    public class UniversityContext : DbContext
    {

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }
        public UniversityContext (DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        
    }
}
