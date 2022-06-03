using KUSYS_Demo.Models.Entities;

namespace KUSYS_Demo.Models
{
    public class StudentUpdateViewModel: StudentViewModel
    {
        public int CourseId { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
