using ASPMVCEDU.Data;
using ASPMVCEDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASPMVCEDU.Controllers
{
    public class RegistrationsController(
        ApplicationDbContext ctx,
        ILogger<RegistrationsController> logger
        ) : Controller
    {

        public IActionResult Index()
        {
            var Registrations = ctx.Registrations.Include(r => r.Class).Include(r => r.Student).Include(r => r.Class.Course).Include(r => r.Class.Teacher).ToList();
            var registrationViewModel = new List<RegistrationViewModel>();

            foreach (var registration in Registrations)
            {
                var thisViewModel = new RegistrationViewModel
                {
                    RegistrationId = registration.RegistrationId,
                    ClassID = registration.Class.ClassId,
                    CourseName = registration.Class.Course.CourseName,
                    TeacherFirstName = registration.Class.Teacher.FirstName,
                    TeacherLastName = registration.Class.Teacher.LastName,
                    StudentID = registration.Student.StudentId,
                    StudentFirstName = registration.Student.FirstName,
                    StudentLastName = registration.Student.LastName,
                    RegistrationDate = registration.RegistrationDate,
                    Mark = registration.Mark
                };

                registrationViewModel.Add(thisViewModel);
            }

            return View(registrationViewModel);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(RegistrationViewModel registrationView)
        {
            if(ctx.Classes.Find(registrationView.ClassID) != null && ctx.Students.Find(registrationView.StudentID) != null)
            {
                var registration = new Registration
                {
                    Class = ctx.Classes.Find(registrationView.ClassID)!,
                    Student = ctx.Students.Find(registrationView.StudentID)!,
                    RegistrationDate = registrationView.RegistrationDate,
                    Mark = registrationView.Mark
                };

                ctx.Registrations.Add(registration);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(registrationView);
            }

            
        }

        public IActionResult Remove(int id)
        {
            var model = ctx.Registrations.Find(id);
            ctx.Registrations.Remove(model!);
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
