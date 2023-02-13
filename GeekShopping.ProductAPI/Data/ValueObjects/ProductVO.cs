namespace GeekShopping.ProductAPI.Data.ValueObjects;

public class ProductVO
{
	public long Id { get; set; }
	public decimal Price { get; set; }
	public string Description { get; set; } = default!;
	public string CategoryName { get; set; } = default!;
	public string ImageUrl { get; set; } = default!;
}
