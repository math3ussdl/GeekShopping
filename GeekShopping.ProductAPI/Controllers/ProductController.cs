using FluentValidation;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public sealed class ProductController : ControllerBase
{
	private readonly IProductRepository _productRepository;
	private readonly IValidator<ProductVo> _validator;

	public ProductController(IProductRepository repository, IValidator<ProductVo> validator)
	{
		_productRepository = repository ?? throw new ArgumentNullException(nameof(repository));
		_validator = validator ?? throw new ArgumentNullException(nameof(validator));
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<ProductVo>>> FindAll()
	{
		var products = await _productRepository.FindAll();
		return Ok(products);
	}

	[HttpGet("{id:long}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ProductVo>> FindById(long id)
	{
		var product = await _productRepository.FindById(id);

		if (product is null) return NotFound();

		return Ok(product);
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<ProductVo>> Create([FromBody] ProductVo vo)
	{
		var validationResult = await _validator.ValidateAsync(vo);

		if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

		var product = await _productRepository.Create(vo);
		return Created(new Uri(Request.Path + product.Id), product);
	}

	[HttpPut]
	public async Task<ActionResult<ProductVo>> Update(ProductVo vo)
	{
		var validationResult = await _validator.ValidateAsync(vo);

		if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

		var product = await _productRepository.Update(vo);
		return Ok(product);
	}

	[HttpDelete("{id:long}")]
	public async Task<ActionResult> Delete(long id)
	{
		var status = await _productRepository.Delete(id);

		if (!status) return BadRequest();

		return Ok(status);
	}
}
