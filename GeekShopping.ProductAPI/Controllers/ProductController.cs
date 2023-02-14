using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public sealed class ProductController : ControllerBase
{
	private readonly IProductRepository _productRepository;

	public ProductController(IProductRepository repository)
	{
		_productRepository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
	{
		var products = await _productRepository.FindAll();
		return Ok(products);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<ProductVO>> FindById(long id)
	{
		var product = await _productRepository.FindById(id);

		if (product is null) return NotFound();

		return Ok(product);
	}
}
