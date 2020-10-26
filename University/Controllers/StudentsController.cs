using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Filters;
using University.Models.Entities;
using University.Models.ViewModels;

namespace University.Controllers
{
    //[ModelIsValidFilter]
    public class StudentsController : Controller
    {
        private readonly UniversityContext db;
        private readonly IMapper mapper;
        private Faker faker;

        public StudentsController(UniversityContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
            faker = new Faker("sv");
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            //var model = db.Students
            //                .Include(s => s.Adress)
            //                .Select(s => new StudentListViewModel
            //                {
            //                    Id = s.Id,
            //                    Avatar = s.Avatar,
            //                    FullName = s.FullName,
            //                    AdressStreet = s.Adress.Street
            //                })
            //                .Take(10);

            var model = mapper.ProjectTo<StudentListViewModel>(db.Students).Take(10);

            return View(await model.ToListAsync());
        }

        public IActionResult CheckEmail(string email)
        {
            if(db.Students.Any(s => s.Email == email))
            {
                return Json($"{email} is in use");
            }
            return Json(true);
        }

        // GET: Students/Details/5
        [RequiredParamFilter("id")]
        [ModelNotNullFilter]
        public async Task<IActionResult> Details(int? id)
        {
            var student = await mapper
                .ProjectTo<StudentDetailsViewModel>(db.Students)
                .FirstOrDefaultAsync(s => s.Id == id);

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // [ModelIsValidFilter]
        public async Task<IActionResult> Create(StudentAddViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                //var student = new Student
                //{
                //    Avatar = faker.Internet.Avatar(),
                //    FirstName = viewmodel.FirstName,
                //    LastName = viewmodel.LastName,
                //    Email = viewmodel.Email,
                //    Adress = new Adress
                //    {
                //        Street = viewmodel.AdressStreet,
                //        City = viewmodel.AdressCity,
                //        ZipCode = viewmodel.AdressZipCode
                //    }
                //};

                var student = mapper.Map<Student>(viewmodel);
                student.Avatar = faker.Internet.Avatar();

                db.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        // GET: Students/Edit/5
        [RequiredParamFilter("id")]
        [ModelNotNullFilter]
        public async Task<IActionResult> Edit(int? id)
        {
            var student = await db.Students.FindAsync(id);
          
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Avatar,FirstName,LastName,Email")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(student);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await db.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await db.Students.FindAsync(id);
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return db.Students.Any(e => e.Id == id);
        }
    }
}
