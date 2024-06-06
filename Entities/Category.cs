using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    [Required, MaxLength(20)]
    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
}
