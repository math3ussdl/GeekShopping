namespace GeekShopping.Web.Models;

public class ProductModel
{
	public long Id { get; set; }
	public decimal Price { get; set; }
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
	public string CategoryName { get; set; } = default!;
	public string ImageUrl { get; set; } = default!;
}
