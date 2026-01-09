using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Product
    {
        public int Id { get; set; }
     
        public string Name { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("category")]
        public int CId { get; set; }
        public virtual Category category { get; set; }
       
    }
}
