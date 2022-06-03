namespace KUSYS_Demo.Models.Entities
{
    public class Student : IEntity
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CourseId { get; set; }
    }
}
