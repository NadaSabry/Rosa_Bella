﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Rosa_Bella.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Rosa_Bella.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Rosa_Bella.Models.Image", b =>
                {
                    b.Property<int?>("productId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("productId", "ImageUrl");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Rosa_Bella.Models.ImagesSlideShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ImagesSlideShows");
                });

            modelBuilder.Entity("Rosa_Bella.Models.Like", b =>
                {
                    b.Property<int?>("productId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("productId", "userId");

                    b.HasIndex("userId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Rosa_Bella.Models.MainCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoyImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MainCategorys");
                });

            modelBuilder.Entity("Rosa_Bella.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MainCategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProductAddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("ProductPrice")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<int?>("ProductQuantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("SeasonID")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("productTypeID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MainCategoryID");

                    b.HasIndex("SeasonID");

                    b.HasIndex("UserId");

                    b.HasIndex("productTypeID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Rosa_Bella.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Rosa_Bella.Models.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Rosa_Bella.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Age")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Rosa_Bella.Models.Comment", b =>
                {
                    b.HasOne("Rosa_Bella.Models.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId");

                    b.HasOne("Rosa_Bella.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Rosa_Bella.Models.Image", b =>
                {
                    b.HasOne("Rosa_Bella.Models.Product", "Products")
                        .WithMany("Images")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Rosa_Bella.Models.Like", b =>
                {
                    b.HasOne("Rosa_Bella.Models.Product", "Product")
                        .WithMany("Likes")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rosa_Bella.Models.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Rosa_Bella.Models.Product", b =>
                {
                    b.HasOne("Rosa_Bella.Models.MainCategory", "MainCategorys")
                        .WithMany("Products")
                        .HasForeignKey("MainCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rosa_Bella.Models.Season", "Seasons")
                        .WithMany("Products")
                        .HasForeignKey("SeasonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rosa_Bella.Models.User", null)
                        .WithMany("Products")
                        .HasForeignKey("UserId");

                    b.HasOne("Rosa_Bella.Models.ProductType", "ProductTypes")
                        .WithMany("Products")
                        .HasForeignKey("productTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCategorys");

                    b.Navigation("ProductTypes");

                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("Rosa_Bella.Models.MainCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Rosa_Bella.Models.Product", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Images");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Rosa_Bella.Models.ProductType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Rosa_Bella.Models.Season", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Rosa_Bella.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
