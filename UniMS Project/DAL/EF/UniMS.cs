using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class UniMS : DbContext
    {
        public UniMS(DbContextOptions<UniMS> options) : base(options)
        {

        }

    }
}
