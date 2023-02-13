﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeekShopping.ProductAPI.Models.Base;

namespace GeekShopping.ProductAPI.Models;

[Table("product")]
public class Product : BaseEntity
{
	[Column("name")]
	[Required]
	[StringLength(150)]
	public string Name { get; set; } = default!;

	[Column("price")]
	[Required]
	[Range(1, 10000)]
	public decimal Price { get; set; }

	[Column("description")]
	[StringLength(500)]
	public string Description { get; set; } = default!;

	[Column("category_name")]
	[StringLength(50)]
	public string CategoryName { get; set; } = default!;

	[Column("image_url")]
	[StringLength(300)]
	public string ImageUrl { get; set; } = default!;
}