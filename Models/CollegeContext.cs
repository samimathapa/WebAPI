using Microsoft.EntityFrameworkCore;
namespace TryWebAPI.Models
{
    public class CollegeContext:DbContext
    {
        public CollegeContext(DbContextOptions<CollegeContext> options): base(options)
        {
        }
        public DbSet<College> Colleges { get; set; }
    }
}
