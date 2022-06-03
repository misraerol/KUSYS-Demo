using KUSYS_Demo.Models;
using KUSYS_Demo.Models.Entities;
using KUSYS_Demo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            List<Course> courses = _courseRepository.GetAll();
            List<CourseViewModel> list = new List<CourseViewModel>();
            foreach (var item in courses)
            {
                CourseViewModel courseView = new CourseViewModel()
                {
                    Id = item.Id,
                    CourseId = item.CourseId,
                    CourseName = item.CourseName,
                };
                list.Add(courseView);
            }

            return View(list);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult Insert(Course course)
        {
            _courseRepository.Add(course);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _courseRepository.Delete(new Course { Id=id});
            return RedirectToAction(nameof(Index));
        }


    }
}
