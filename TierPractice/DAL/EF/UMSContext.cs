using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class UMSContext : DbContext
    {
        public UMSContext(DbContextOptions<UMSContext>option):base(option) { }
        public DbSet<Student> students { get; set; }
    }
}
