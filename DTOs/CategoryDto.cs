using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CategoryDto
    {
        [Required]
        public int CategoryId { get; set; }

        [Required, MaxLength(20)]
        public string CategoryName { get; set; } = null!;

    }
}
