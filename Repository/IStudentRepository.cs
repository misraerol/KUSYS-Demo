using KUSYS_Demo.Models.Entities;

namespace KUSYS_Demo.Repository
{
    public interface IStudentRepository
    {
        void Add(Student student);
        void Delete(Student student);
        void Update(Student student);
        List<Student> GetAll();
        Student GetById(int Id);
    }
}
