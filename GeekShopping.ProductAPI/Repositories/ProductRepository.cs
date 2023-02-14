﻿using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Models;
using GeekShopping.ProductAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repositories;

public class ProductRepository : IProductRepository
{
	private readonly PostgresContext _context;
	private readonly IMapper _mapper;

	public ProductRepository(PostgresContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public async Task<IEnumerable<ProductVo>> FindAll()
	{
		List<Product> products = await _context.Products.ToListAsync();
		return _mapper.Map<List<ProductVo>>(products);
	}

	public async Task<ProductVo?> FindById(long id)
	{
		Product? product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

		if (product is null) return null;

		return _mapper.Map<ProductVo>(product);
	}

	public async Task<ProductVo> Create(ProductVo vo)
	{
		Product product = _mapper.Map<Product>(vo);
		_context.Products.Add(product);
		await _context.SaveChangesAsync();

		return _mapper.Map<ProductVo>(product);
	}

	public async Task<ProductVo> Update(ProductVo vo)
	{
		Product product = _mapper.Map<Product>(vo);
		_context.Products.Update(product);
		await _context.SaveChangesAsync();

		return _mapper.Map<ProductVo>(product);
	}

	public async Task<bool> Delete(long id)
	{
		try
		{
			Product? product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

			if (product is null)
			{
				return false;
			}

			_context.Products.Remove(product);
			await _context.SaveChangesAsync();

			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
