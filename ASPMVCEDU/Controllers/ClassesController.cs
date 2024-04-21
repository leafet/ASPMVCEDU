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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
