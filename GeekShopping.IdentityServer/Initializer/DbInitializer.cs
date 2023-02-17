using System.Security.Claims;
using GeekShopping.IdentityServer.Models.Context;
using GeekShopping.IdentityServer.Initializer.Interfaces;
using GeekShopping.IdentityServer.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace GeekShopping.IdentityServer.Initializer;

public sealed class DbInitializer : IDbInitializer
{
  private readonly ApplicationDbContext _context;
  private readonly UserManager<ApplicationUser> _user;
  private readonly RoleManager<IdentityRole> _role;

  public DbInitializer(
    ApplicationDbContext context,
    UserManager<ApplicationUser> user,
    RoleManager<IdentityRole> role)
  {
    _context = context;
    _user = user;
    _role = role;
  }
  
  public void Initialize()
  {
    if (_role.FindByIdAsync(IdentityConfiguration.Admin).Result is not null)
      return;

    _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
    _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

    ApplicationUser admin = new()
    {
      UserName = "root",
      Email = "limabrot879@gmail.com",
      EmailConfirmed = true,
      PhoneNumber = "+55 (81) 93618-4134",
      PhoneNumberConfirmed = true,
      Name = "Geek Admin"
    };

    _user.CreateAsync(admin, "Geek_Admin123!").GetAwaiter().GetResult();
    _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

    var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
    {
      new(JwtClaimTypes.Name, admin.Name),
      new(JwtClaimTypes.NickName, admin.UserName),
      new(JwtClaimTypes.Email, admin.Email),
      new(JwtClaimTypes.Role, IdentityConfiguration.Admin)
    }).Result;
    
    ApplicationUser client = new()
    {
      UserName = "basl.dev",
      Email = "basl.dev1610@gmail.com",
      EmailConfirmed = true,
      PhoneNumber = "+55 (81) 91982-0912",
      PhoneNumberConfirmed = true,
      Name = "Bruno Lima"
    };

    _user.CreateAsync(client, "Bruno_0912!").GetAwaiter().GetResult();
    _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

    var clientClaims = _user.AddClaimsAsync(client, new Claim[]
    {
      new(JwtClaimTypes.Name, client.Name),
      new(JwtClaimTypes.NickName, client.UserName),
      new(JwtClaimTypes.Email, client.Email),
      new(JwtClaimTypes.Role, IdentityConfiguration.Client)
    }).Result;
  }
}
