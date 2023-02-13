using AutoMapper;
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

  public async Task<IEnumerable<ProductVO>> FindAll()
  {
    List<Product> products = await _context.Products.ToListAsync();
    return _mapper.Map<List<ProductVO>>(products);
  }

  public async Task<ProductVO> FindById(long id)
  {
    Product? product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

    if (product is null)
    {
      throw new ApplicationException("Product is not found");
    }

    return _mapper.Map<ProductVO>(product);
  }

  public async Task<ProductVO> Create(ProductVO vo)
  {
    Product product = _mapper.Map<Product>(vo);
    _context.Products.Add(product);
    await _context.SaveChangesAsync();

    return _mapper.Map<ProductVO>(product);
  }

  public async Task<ProductVO> Update(ProductVO vo)
  {
    Product product = _mapper.Map<Product>(vo);
    _context.Products.Update(product);
    await _context.SaveChangesAsync();

    return _mapper.Map<ProductVO>(product);
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
    catch (System.Exception)
    {
      return false;
    }
  }
}
