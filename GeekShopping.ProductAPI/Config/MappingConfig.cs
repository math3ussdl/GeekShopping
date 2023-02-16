using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Models;

namespace GeekShopping.ProductAPI.Config;

public sealed class MappingConfig
{
  public static MapperConfiguration RegisterMaps()
  {
    var mappingConfig = new MapperConfiguration(cfg =>
    {
      cfg.CreateMap<ProductVo, Product>().ReverseMap();
    });
    return mappingConfig;
  }
}
