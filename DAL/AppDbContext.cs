using Microsoft.EntityFrameworkCore;
using StudentDemo.Models;
using StudentDemo.ViewModels;

namespace StudentDemo.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Student> students { get; set; }    
        public DbSet<StudentDemo.ViewModels.StudentViewModel> StudentViewModel { get; set; }
    }
}
