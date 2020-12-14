using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using University.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace University.Data
{
    public class UniversityRepository
    {
        private readonly UniversityContext db;
        public UniversityRepository(UniversityContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Course>>GetAllCoursesInfo(bool inclenrollments = false)
        {
             return inclenrollments ? await db.Course.
                Include(a => a.Enrollments).ToListAsync() :
                await db.Course.ToListAsync();
                 
            //db.Course.Include(a => a.Enrollments);
            //var courses = db.Course.ToListAsync();
            //return await courses;
        }

        public async Task<Course>GetCoursebyName(string name) 
        {
            return await db.Course.FirstOrDefaultAsync(n => n.Title == name);
                
        }

    }
}
