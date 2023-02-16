using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeekShopping.ProductAPI.Models.Base;

namespace GeekShopping.ProductAPI.Models;

[Table("product")]
public class Product : BaseEntity
{
	[Column("name")]
	public string Name { get; set; } = default!;

	[Column("price")]
	public decimal Price { get; set; }

	[Column("description")]
	public string Description { get; set; } = default!;

	[Column("category_name")]
	public string CategoryName { get; set; } = default!;

	[Column("image_url")]
	public string ImageUrl { get; set; } = default!;
}
