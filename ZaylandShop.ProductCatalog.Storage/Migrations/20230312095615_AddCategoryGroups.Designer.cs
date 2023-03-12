﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZaylandShop.ProductCatalog.Storage;

#nullable disable

namespace ZaylandShop.ProductCatalog.Storage.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230312095615_AddCategoryGroups")]
    partial class AddCategoryGroups
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<long>("CategoriesId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductsId")
                        .HasColumnType("bigint");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("ProductCategories", (string)null);
                });

            modelBuilder.Entity("ZaylandShop.ProductCatalog.Entities.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.HasKey("Id");

                    b.ToTable("Brands", (string)null);
                });

            modelBuilder.Entity("ZaylandShop.ProductCatalog.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<int>("Group")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("ZaylandShop.ProductCatalog.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("Description")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ProductColorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ProductColorId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("ZaylandShop.ProductCatalog.Entities.ProductColor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("Hex")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.HasKey("Id");

                    b.ToTable("ProductColors", (string)null);
                });

            modelBuilder.Entity("ZaylandShop.ProductCatalog.Entities.ProductFile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductFiles", (string)null);
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("ZaylandShop.ProductCatalog.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZaylandShop.ProductCatalog.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZaylandShop.ProductCatalog.Entities.Product", b =>
                {
                    b.HasOne("ZaylandShop.ProductCatalog.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZaylandShop.ProductCatalog.Entities.ProductColor", "ProductColor")
                        .WithMany("Products")
                        .HasForeignKey("ProductColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("ProductColor");
                });

            modelBuilder.Entity("ZaylandShop.ProductCatalog.Entities.ProductFile", b =>
                {
                    b.HasOne("ZaylandShop.ProductCatalog.Entities.Product", "Product")
                        .WithMany("Files")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ZaylandShop.ProductCatalog.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ZaylandShop.ProductCatalog.Entities.Product", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("ZaylandShop.ProductCatalog.Entities.ProductColor", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
