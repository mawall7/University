using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models.DTO;
using University.Models.Entities;

namespace University.Controllers
{
    [Route("api/courses")]
    public class CoursesController : Controller
    {
        private UniversityRepository repo;

        private readonly IMapper mapper;

        public CoursesController(UniversityContext context, IMapper mapper)
        {
            repo = new UniversityRepository(context); 
          
            this.mapper = mapper;
        }

        // GET: Courses
        [HttpGet]
        //[Route("{name}")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCoursesinfo(bool inclenrollements = false)
        {
            var courses = await repo.GetAllCoursesInfo(inclenrollements);
            var mappedres = (mapper.Map<IEnumerable<CourseDto>>(courses));
            return Ok(mappedres);
        }

        public async Task<ActionResult<CourseDto>> GetCourse(string name)
        {
            var course = repo.GetCoursebyName(name);
            return mapper.Map<CourseDto>(course);
        }

//        [HttpGet]
//        [Route("{name}")]
//        public async Task<IActionResult> GetCourseinfo()
//        {
//            return View(await _context.Course.ToListAsync());
//        }

//        // GET: Courses/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var course = await _context.Course
//                .Include(c => c.Enrollments)
//                .ThenInclude(e => e.Student)
//                .FirstOrDefaultAsync(m => m.Id == id);

//            if (course == null)
//            {
//                return NotFound();
//            }

//            return View(course);
//        }

//        // GET: Courses/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Courses/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Title")] Course course)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(course);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(course);
//        }

//        // GET: Courses/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var course = await _context.Course.FindAsync(id);
//            if (course == null)
//            {
//                return NotFound();
//            }
//            return View(course);
//        }

//        // POST: Courses/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Course course)
//        {
//            if (id != course.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(course);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!CourseExists(course.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(course);
//        }

//        // GET: Courses/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var course = await _context.Course
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (course == null)
//            {
//                return NotFound();
//            }

//            return View(course);
//        }

//        // POST: Courses/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var course = await _context.Course.FindAsync(id);
//            _context.Course.Remove(course);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool CourseExists(int id)
//        {
//            return _context.Course.Any(e => e.Id == id);
//        }
  }
}
