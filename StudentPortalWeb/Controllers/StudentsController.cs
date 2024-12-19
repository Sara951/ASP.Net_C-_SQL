using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortalWeb.Data;
using StudentPortalWeb.Models;
using StudentPortalWeb.Models.Entities;

namespace StudentPortalWeb.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet] //GET /students
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost] //POST /student
        public async Task<ActionResult> Add(AddStudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    Subscribed = viewModel.Subscribed
                };

                await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();
            }

            return View(viewModel);
        }

        [HttpGet] //GET /students       
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }
        [HttpGet] //GET /students/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);
            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Subscribed = viewModel.Subscribed;
                
                await dbContext.SaveChangesAsync();
                dbContext.SaveChanges();
                return RedirectToAction("List", "Students");
            }
            return NotFound();
        }
        [HttpPost]
       public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students.FirstOrDefaultAsync(x => x.Id==viewModel.Id);
            if (student is not null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("List", "Students");
            }
            return NotFound();
        }



    }
}
