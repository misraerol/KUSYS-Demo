using KUSYS_Demo.Models.Entities;
using KUSYS_Demo.Repository;

namespace KUSYS_Demo.DAL
{
    public class CourseDal : EntityRepositoryBase<Course>, ICourseDal
    {
        public CourseDal(AppDbContext context) : base(context)
        {
        }
    }
}
