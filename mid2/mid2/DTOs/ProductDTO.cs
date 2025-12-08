using mid2.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mid2.DTOs
{
    public class ProductDTO
    {
       
            public int Id { get; set; }
        [Required]
            public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
            public int QTY { get; set; }
            public int CId { get; set; }

            public virtual Catagory Catagory { get; set; }
        
    }
}