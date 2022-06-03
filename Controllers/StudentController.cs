using KUSYS_Demo.Models;
using KUSYS_Demo.Models.Entities;
using KUSYS_Demo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Controllers
{
    public class StudentController : Controller
    {
        ICourseRepository _courseRepository;
        IStudentRepository _studentRepository;

        public StudentController(ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }


        public IActionResult Index()
        {
            List<Student> students = _studentRepository.GetAll();
            List<StudentViewModel> list = new List<StudentViewModel>();
            foreach (var item in students)
            {
                var course = _courseRepository.GetById(item.CourseId);
                StudentViewModel studentView = new StudentViewModel()
                {
                    StudentId = item.StudentId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    BirthDate = item.BirthDate,
                    CourseName = course.CourseName != null ? course.CourseName : string.Empty,
                };
                list.Add(studentView);
            }

            return View(list);
        }
        [HttpGet]
        public IActionResult Insert()
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
        [HttpPost]
        public IActionResult Insert(Student student)
        {
            _studentRepository.Add(student);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var student=_studentRepository.GetById(id);
            var course = _courseRepository.GetById(student.CourseId);

            StudentUpdateViewModel studentView = new StudentUpdateViewModel()
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                BirthDate = student.BirthDate,
                Courses = _courseRepository.GetAll(),
                CourseName = course.CourseName != null ? course.CourseName : string.Empty,
                CourseId = course.Id
            };

            return View(studentView);
            
        }

        [HttpPost]
        public ActionResult Update(Student student)
        {
            _studentRepository.Update(student);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _studentRepository.Delete(new Student { StudentId = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
