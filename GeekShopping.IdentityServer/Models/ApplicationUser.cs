using Microsoft.AspNetCore.Identity;

namespace GeekShopping.IdentityServer.Models;

public class ApplicationUser : IdentityUser
{
  public string Name { get; set; }
}
