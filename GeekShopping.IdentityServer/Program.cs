using GeekShopping.IdentityServer;
using GeekShopping.IdentityServer.Data;
using GeekShopping.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
  opts.UseNpgsql(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
  .AddEntityFrameworkStores<ApplicationDbContext>()
  .AddDefaultTokenProviders();

builder.Services.AddRazorPages();

var identityBuilder = builder.Services
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
  .AddInMemoryClients(IdentityConfiguration.Clients)
  .AddAspNetIdentity<ApplicationUser>();

identityBuilder.AddDeveloperSigningCredential();

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

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();

app.MapRazorPages()
  .RequireAuthorization();

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();