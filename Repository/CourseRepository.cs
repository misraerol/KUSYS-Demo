using KUSYS_Demo.DAL;
using KUSYS_Demo.Models.Entities;

namespace KUSYS_Demo.Repository
{
    public class CourseRepository : ICourseRepository
    {
        ICourseDal _courseDal;

        public CourseRepository(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }
        public void Add(Course course)
        {
            _courseDal.Add(course);
        }

        public void Delete(Course course)
        {
            _courseDal.Delete(course);
        }

        public List<Course> GetAll()
        {
            return new List<Course>(_courseDal.GetAll());
        }
        public Course GetById(int Id)
        {
            Course course = _courseDal.Get(s => s.Id == Id);
            return new Course()
            {
                 CourseId=course.CourseId,
                 Id=course.Id,
                 CourseName=course.CourseName
            };

        }
    }
}
