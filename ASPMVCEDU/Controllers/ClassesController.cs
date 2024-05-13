using ASPMVCEDU.Data;
using ASPMVCEDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASPMVCEDU.Controllers
{
    public class ClassesController(
        ApplicationDbContext ctx
        ) : Controller
    {
        public IActionResult Index()
        {
            var Classes = ctx.Classes.Include(c => c.Course).Include(c => c.Teacher).ToList();
            var classViewModel = new List<ClassViewModel>();

            foreach (var clas in Classes)
            {
                var thisViewModel = new ClassViewModel
                {
                    ClassId = clas.ClassId,
                    Course = clas.Course,
                    Teacher = clas.Teacher,
                    StartDate = clas.StartDate,
                    EndDate = clas.EndDate,
                    Duration = clas.Duration
                };

                classViewModel.Add(thisViewModel);
            }

            return View(classViewModel);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(ClassViewModel classView)
        {
            if (ctx.Courses.Find(classView.CourseId) != null && ctx.Teachers.Find(classView.TeacherId) != null)
            {
                var clas = new Class
                {
                    Course = ctx.Courses.Find(classView.CourseId)!,
                    Teacher = ctx.Teachers.Find(classView.TeacherId)!,
                    StartDate = classView.StartDate,
                    EndDate = classView.EndDate,
                    Duration = classView.Duration
                };

                ctx.Classes.Add(clas);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(classView);
            }


        }

        public IActionResult Remove(int id)
        {
            var model = ctx.Classes.Find(id);
            ctx.Classes.Remove(model!);
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
