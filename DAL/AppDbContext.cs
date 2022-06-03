using KUSYS_Demo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KUSYS_Demo.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }


    }
}
