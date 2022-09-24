﻿using System.ComponentModel.DataAnnotations;

namespace Rosa_Bella.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? CategoryName { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}
