﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Software_Project.Models;

public class Like
{
    [ForeignKey("Product")]
    public int? productId { get; set; }

    [ForeignKey("User")]
    public int? userId { get; set; }

    public virtual Product? Product { get; set; }
    public virtual User? User { get; set; }
}
