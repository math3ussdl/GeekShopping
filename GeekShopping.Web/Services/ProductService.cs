using GeekShopping.Web.Models;
using GeekShopping.Web.Services.Interfaces;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services;

public class ProductService : IProductService
{
  private readonly HttpClient _client;
  private const string BasePath = "api/v1/product";

  public ProductService(HttpClient client)
  {
    _client = client;
  }
  
  public async Task<IEnumerable<ProductModel>> FindAllProducts()
  {
    var response = await _client.GetAsync(BasePath);
    return await response.ReadContentAs<List<ProductModel>>();
  }
  
  public async Task<ProductModel> FindProductById(long id)
  {
    var response = await _client.GetAsync($"{BasePath}/{id}");
    return await response.ReadContentAs<ProductModel>();
  }
  
  public async Task<ProductModel> CreateProduct(ProductModel model)
  {
    var response = await _client.PostAsJson(BasePath, new
    {
      model.Name,
      model.Price,
      model.Description,
      model.CategoryName,
      model.ImageUrl
    });

    if (!response.IsSuccessStatusCode)
      throw new ApplicationException($"Something went wrong when calling api: {response.ReasonPhrase}");

    return await response.ReadContentAs<ProductModel>();
  }
  
  public async Task<ProductModel> UpdateProduct(ProductModel model)
  {
    var response = await _client.PutAsJson(BasePath, model);

    if (!response.IsSuccessStatusCode)
      throw new ApplicationException($"Something went wrong when calling api: {response.ReasonPhrase}");

    return await response.ReadContentAs<ProductModel>();
  }
  
  public async Task<bool> DeleteProductById(long id)
  {
    var response = await _client.DeleteAsync($"{BasePath}/{id}");

    if (!response.IsSuccessStatusCode)
      throw new ApplicationException($"Something went wrong when calling api: {response.ReasonPhrase}");

    return await response.ReadContentAs<bool>();
  }
}
