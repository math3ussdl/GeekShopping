using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Models.Base;

public class BaseEntity
{
	[Key]
	[Column("id")]
	public long Id { get; set; }

	[Column("created_at")]
	public DateTime CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime UpdatedAt { get; set; }
}
