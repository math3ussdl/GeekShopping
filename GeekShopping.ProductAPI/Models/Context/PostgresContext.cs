using GeekShopping.ProductAPI.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Models.Context;

public sealed class PostgresContext : DbContext
{
	public PostgresContext()
	{
	}

	public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
	{
	}

	public DbSet<Product> Products { get; set; } = default!;

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
	{
		var entries = ChangeTracker
			.Entries()
			.Where(e => e.Entity is BaseEntity && (
				e.State == EntityState.Added
				|| e.State == EntityState.Modified));

		foreach (var entry in entries)
		{
			((BaseEntity)entry.Entity).UpdatedAt = DateTime.Now;

			if (entry.State == EntityState.Added)
			{
				((BaseEntity)entry.Entity).CreatedAt = DateTime.Now;
			}
		}

		return base.SaveChangesAsync(cancellationToken);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Product>().HasData(new Product
		{
			Id = 1,
			Name = "Carta Yu-Gi-Oh Rara",
			Price = new decimal(22000.0),
			ImageUrl = "https://s2.glbimg.com/qnz29OQJebXxDQo-slkyH68WWBA=/0x0:444x643/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_bc8228b6673f488aa253bbcb03c80ec5/internal_photos/bs/2021/A/e/dyDPEFST6Ezs8CqBTnQg/dragao.jpg",
			Description = "Carta rara que paralisou leilao!",
			CategoryName = "Hobby"
		});

		modelBuilder.Entity<Product>().HasData(new Product
		{
			Id = 2,
			Name = "Caneta esferográfica azul",
			Price = new decimal(2),
			ImageUrl = "https://img.kalunga.com.br/fotosdeprodutos/176072z_2.jpg",
			Description = "Caneta azul, azul canetaaa...",
			CategoryName = "Escolar"
		});

		modelBuilder.Entity<Product>().HasData(new Product
		{
			Id = 3,
			Name = "Caderno Tilibra Azul",
			Price = new decimal(6.50),
			ImageUrl = "https://m.media-amazon.com/images/I/51Z8ZM4sj8L._AC_SX679_.jpg",
			Description = "Aproveite essa volta às aulas com estilo!",
			CategoryName = "Escolar"
		});
	}
}
