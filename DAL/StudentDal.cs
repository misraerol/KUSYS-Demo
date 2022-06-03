using KUSYS_Demo.Models.Entities;
using KUSYS_Demo.Repository;

namespace KUSYS_Demo.DAL
{
    public class StudentDal : EntityRepositoryBase<Student>, IStudentDal
    {
        public StudentDal(AppDbContext context) : base(context)
        {
        }
    }
}
