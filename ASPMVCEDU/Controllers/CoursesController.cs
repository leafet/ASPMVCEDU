using ASPMVCEDU.Data;
using ASPMVCEDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASPMVCEDU.Controllers
{
    public class CoursesController(
        ApplicationDbContext ctx
        ) : Controller
    {

        public IActionResult Index()
        {
            var Courses = ctx.Courses.ToList();
            var courseViewModel = new List<CourseViewModel>();

            foreach (var course in Courses)
            {
                var thisViewModel = new CourseViewModel
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    Description = course.Description,
                    Duration = course.Duration,
                    Price = course.Price
                };

                courseViewModel.Add(thisViewModel);
            }

            return View(courseViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
