using ASPMVCEDU.Data;
using ASPMVCEDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASPMVCEDU.Controllers
{
    public class StudentsController(
        ApplicationDbContext ctx
        ) : Controller
    {

        public IActionResult Index()
        {
            var Students = ctx.Students.ToList();
            var studentViewModel = new List<StudentViewModel>();

            foreach (var student in Students)
            {

                var thisViewModel = new StudentViewModel
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Adress = student.Adress,
                    Email = student.Email,
                    Phone = student.Phone
                };

                studentViewModel.Add(thisViewModel);
            }

            return View(studentViewModel);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(StudentViewModel studentView)
        {
            var student = new Student
            {
                FirstName = studentView.FirstName,
                LastName = studentView.LastName,
                Adress = studentView.Adress,
                Email = studentView.Email,
                Phone = studentView.Phone
            };

            if (ModelState.IsValid)
            {
                ctx.Students.Add(student);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentView);
        }

        public IActionResult Remove(int id)
        {
            var model = ctx.Students.Find(id);
            ctx.Students.Remove(model!);
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
