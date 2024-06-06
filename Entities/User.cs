using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    [Required]
    public int UserId { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; } = null!;
    [MaxLength(20)]
    public string? FirstName { get; set; }
    [MaxLength(20)]
    public string? LastName { get; set; }
    [Required]
    public string Password { get; set; } = null!;

    public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
}
