using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ProductDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required, MaxLength(20)]
        public string ProductName { get; set; } = null!;
        [Required]
        public int Price { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [MaxLength(100)]
        public string? ImageUrl { get; set; }

    }
}
