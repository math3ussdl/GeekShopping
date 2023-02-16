using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GeekShopping.Web;
using GeekShopping.Web.Services;
using GeekShopping.Web.Services.Interfaces;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddSingleton(sp => new HttpClient
{
  BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseUrl") ?? "http://localhost:5200")
});

builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
