using System.ComponentModel.DataAnnotations;

namespace KUSYS_Demo.Models.Entities
{
    public class Course : IEntity
    {
        [Key]
        public int Id { get; set; } 
        public string? CourseId { get; set; }
        public string? CourseName { get; set; }
    }
}
