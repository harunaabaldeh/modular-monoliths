﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RiverBooks.Books;

#nullable disable

namespace RiverBooks.Books.Data.Migrations
{
    [DbContext(typeof(BookDbContext))]
    [Migration("20241228023827_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Books")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RiverBooks.Books.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasPrecision(16, 8)
                        .HasColumnType("decimal(16,8)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Books", "Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6ae450e7-cb0e-44b5-8ae7-1b65e685fee2"),
                            Author = "J.R.R Tolkien",
                            Price = 10.99m,
                            Title = "The Fellowship of the Ring"
                        },
                        new
                        {
                            Id = new Guid("9ca0782e-b669-46c6-9b34-80bc9f6a8783"),
                            Author = "J.R.R Tolkien",
                            Price = 11.99m,
                            Title = "The Two Towers"
                        },
                        new
                        {
                            Id = new Guid("41ab39b2-2e49-4f0b-b7d9-f53ffe13ff71"),
                            Author = "J.R.R Tolkien",
                            Price = 12.99m,
                            Title = "The Return of the King"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
