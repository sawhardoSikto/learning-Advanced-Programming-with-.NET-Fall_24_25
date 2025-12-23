using EcommerceMS.EF.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceMS.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("cate")]
        public int Cid { get; set; }
        public decimal Price { get; set; }
        public Category cate { get; set; }

    }
}
