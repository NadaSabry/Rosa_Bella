﻿using Rosa_Bella.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext :DbContext
{
     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
     {

     }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Like>()
            .HasKey(b => new { b.productId, b.userId });

        modelBuilder.Entity<Image>()
            .HasKey(b => new { b.productId, b.ImageUrl });
    }

    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<MainCategory> MainCategorys { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<ImagesSlideShow> ImagesSlideShows { get; set; }
    


}

