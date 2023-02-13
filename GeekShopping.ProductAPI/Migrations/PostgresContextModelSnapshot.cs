﻿// <auto-generated />
using GeekShopping.ProductAPI.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace GeekShopping.ProductAPI.Migrations
{
  [DbContext(typeof(PostgresContext))]
  partial class PostgresContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("ProductVersion", "7.0.2")
          .HasAnnotation("Relational:MaxIdentifierLength", 63);

      NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

      modelBuilder.Entity("GeekShopping.ProductAPI.Models.Product", b =>
          {
            b.Property<long>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("bigint")
                      .HasColumnName("id");

            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

            b.Property<string>("CategoryName")
                      .IsRequired()
                      .HasMaxLength(50)
                      .HasColumnType("character varying(50)")
                      .HasColumnName("category_name");

            b.Property<DateTime>("CreatedAt")
                      .HasColumnType("timestamp with time zone")
                      .HasColumnName("created_at");

            b.Property<string>("Description")
                      .IsRequired()
                      .HasMaxLength(500)
                      .HasColumnType("character varying(500)")
                      .HasColumnName("description");

            b.Property<string>("ImageUrl")
                      .IsRequired()
                      .HasMaxLength(300)
                      .HasColumnType("character varying(300)")
                      .HasColumnName("image_url");

            b.Property<string>("Name")
                      .IsRequired()
                      .HasMaxLength(150)
                      .HasColumnType("character varying(150)")
                      .HasColumnName("name");

            b.Property<decimal>("Price")
                      .HasColumnType("numeric")
                      .HasColumnName("price");

            b.Property<DateTime>("UpdatedAt")
                      .HasColumnType("timestamp with time zone")
                      .HasColumnName("updated_at");

            b.HasKey("Id");

            b.ToTable("product");
          });
#pragma warning restore 612, 618
    }
  }
}
