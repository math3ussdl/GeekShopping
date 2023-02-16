using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Data.Context;

public sealed class PostgresContext : IdentityDbContext<ApplicationUser>
{
  public PostgresContext(DbContextOptions<PostgresContext> options)
    : base(options)
  {
  }
}
