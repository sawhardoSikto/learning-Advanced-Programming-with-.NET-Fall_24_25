using IntroCodeFAPI.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroCodeFAPI.EF
{
    public class UmsContext : DbContext
    {
        public UmsContext(DbContextOptions<UmsContext> options)
        :base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }    
        public DbSet<Depertment> Depertments { get; set; }
        public DbSet<Courses> Courses { get; set; }
    }
}
