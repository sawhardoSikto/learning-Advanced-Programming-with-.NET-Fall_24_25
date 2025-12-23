using EcommerceMS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMS.EF
{
    public class EmsContext:DbContext
    {
        public EmsContext(DbContextOptions<EmsContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
