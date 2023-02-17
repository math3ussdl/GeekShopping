using GeekShopping.IdentityServer;
using GeekShopping.IdentityServer.Initializer;
using GeekShopping.IdentityServer.Initializer.Interfaces;
using GeekShopping.IdentityServer.Models;
using GeekShopping.IdentityServer.Models.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
  opts.UseNpgsql(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
  .AddEntityFrameworkStores<ApplicationDbContext>()
  .AddDefaultTokenProviders();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddRazorPages();

builder.Services
  .AddIdentityServer(opts =>
    {
      opts.Events.RaiseErrorEvents = true;
      opts.Events.RaiseInformationEvents = true;
      opts.Events.RaiseFailureEvents = true;
      opts.Events.RaiseSuccessEvents = true;
      opts.EmitStaticAudienceClaim = true;
    }
  )
  .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
  .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
  .AddInMemoryClients(IdentityConfiguration.Clients)
  .AddAspNetIdentity<ApplicationUser>()
  .AddDeveloperSigningCredential();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

SeedDatabase();

app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapRazorPages()
  .RequireAuthorization();

app.Run();

void SeedDatabase()
{
  using var scope = app.Services.CreateScope();
  var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
  dbInitializer.Initialize();
}
