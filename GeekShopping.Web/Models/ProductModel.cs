using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Web.Models;

public sealed class ProductModel
{
  public long? Id { get; set; }
  
  [Required]
  [Range(1, 10000, ErrorMessage = "Insira um valor entre 1 e 10000!")]
  public decimal Price { get; set; }
  
  [Required]
  [StringLength(50, ErrorMessage = "O tamanho não pode exceder a 50 caracteres.")]
  public string Name { get; set; } = string.Empty;
  
  [MinLength(6, ErrorMessage = "O tamanho não pode ser menor que 6 caracteres")]
  [StringLength(500, ErrorMessage = "O tamanho não pode exceder a 500 caracteres")]
  public string Description { get; set; } = string.Empty;
  
  [StringLength(50, ErrorMessage = "O tamanho não pode exceder a 50 caracteres")]
  public string CategoryName { get; set; } = string.Empty;
  
  [StringLength(300, ErrorMessage = "O tamanho não pode exceder a 300 caracteres")]
  public string ImageUrl { get; set; }  = string.Empty;
}
