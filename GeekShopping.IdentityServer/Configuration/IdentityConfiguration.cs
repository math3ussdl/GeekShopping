using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GeekShopping.IdentityServer;

public static class IdentityConfiguration
{
  public const string Admin = "Admin";
  public const string Client = "Client";

  public static IEnumerable<IdentityResource> IdentityResources =>
    new List<IdentityResource>
    {
      new IdentityResources.OpenId(),
      new IdentityResources.Email(),
      new IdentityResources.Profile()
    };

  public static IEnumerable<ApiScope> ApiScopes =>
    new List<ApiScope>
    {
      new ApiScope(name: "geek_shopping", displayName: "GeekShopping Server"),
      new ApiScope(name: "read", displayName: "Read your data."),
      new ApiScope(name: "write", displayName: "Write your data."),
      new ApiScope(name: "delete", displayName: "Delete your data.")
    };

  public static IEnumerable<Client> Clients =>
    new List<Client>
    {
      new Client
      {
        ClientId = "client",
        ClientSecrets = { new Secret("secret".Sha256()) },
        AllowedGrantTypes = GrantTypes.ClientCredentials,
        AllowedScopes = { "read", "write", "profile" }
      },
      
      new Client
      {
        ClientId = "geek_shopping",
        ClientSecrets = { new Secret("secret".Sha256()) },
        AllowedGrantTypes = GrantTypes.Code,
        RedirectUris = { "https://localhost:7037/signin-oidc" },
        PostLogoutRedirectUris = { "https://localhost:7037/signout-callback-oidc" },
        AllowedScopes = new List<string>
        {
          IdentityServerConstants.StandardScopes.OpenId,
          IdentityServerConstants.StandardScopes.Profile,
          IdentityServerConstants.StandardScopes.Email,
          "geek_shopping"
        }
      },
    };
}
