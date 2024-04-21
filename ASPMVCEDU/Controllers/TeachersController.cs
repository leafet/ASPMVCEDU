using ASPMVCEDU.Data;
using ASPMVCEDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASPMVCEDU.Controllers
{
    public class TeachersController(
        ApplicationDbContext ctx
        ) : Controller
    {
        public IActionResult Index()
        {
            var Teachers = ctx.Teachers.ToList();
            var teacherViewModel = new List<TeacherViewModel>();

            foreach(var teacher in Teachers)
            {
                var thisViewModel = new TeacherViewModel
                {
                    TeacherId = teacher.TeacherId,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Specialisation = teacher.Specialisation,
                    Email = teacher.Email,
                    Phone = teacher.Phone,
                };

                teacherViewModel.Add(thisViewModel);
            }

            return View(teacherViewModel);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(TeacherViewModel teacherView)
        {
            var teacher = new Teacher
            {
                FirstName = teacherView.FirstName,
                LastName = teacherView.LastName,
                Specialisation = teacherView.Specialisation,
                Email = teacherView.Email,
                Phone = teacherView.Phone
            };

            if (ModelState.IsValid)
            {
                ctx.Teachers.Add(teacher);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacherView);
        }

        public IActionResult Remove(int id) 
        {
            var model = ctx.Teachers.Find(id);
            ctx.Teachers.Remove(model!);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
