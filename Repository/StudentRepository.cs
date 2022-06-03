using KUSYS_Demo.DAL;
using KUSYS_Demo.Models.Entities;

namespace KUSYS_Demo.Repository
{
    public class StudentRepository: IStudentRepository
    {
        IStudentDal _studentDal;

        public StudentRepository(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public void Add(Student student)
        {
            _studentDal.Add(student);
        }

        public void Delete(Student student)
        {
            _studentDal.Delete(student);
        }

        public void Update(Student student)
        {
            _studentDal.Update(student);
        }
        public List<Student> GetAll()
        {
            return new List<Student>(_studentDal.GetAll());
        }
        public Student GetById(int Id)
        {
            Student student = _studentDal.Get(s => s.StudentId == Id);
            return new Student()
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                BirthDate = student.BirthDate,
                CourseId = student.CourseId,
            };

        }
    }
}
