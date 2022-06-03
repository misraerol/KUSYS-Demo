using KUSYS_Demo.Models.Entities;

namespace KUSYS_Demo.Repository
{
    public interface ICourseRepository
    {
        void Add(Course course);
        void Delete(Course course);
        List<Course> GetAll();
        Course GetById(int Id);
    }
}
