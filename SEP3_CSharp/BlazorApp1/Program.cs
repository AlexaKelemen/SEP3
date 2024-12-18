using BlazorApp1.Auth;
using BlazorApp1.Components;
using BlazorApp1.Services;
using BlazorApp1.Services.Contracts;
using DatabaseConnection;
using Grpc.Net.Client;
using BlazorApp1.Managers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
/*builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:8080")
});
builder.Services.AddScoped( sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:8080")
});*/
builder.Services.AddHttpClient("Users", sp =>
{
    sp.BaseAddress = new Uri("http://localhost:8080");
});
builder.Services.AddHttpClient("Products", sp =>
{
    sp.BaseAddress = new Uri("http://localhost:5150");
});
builder.Services.AddHttpClient();

builder.Services.AddSingleton(channel => GrpcChannel.ForAddress("http://localhost:8089"));
builder.Services.AddScoped<IManager, Manager>();
builder.Services.AddScoped<IUserService, HttpUserService>();
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthProvider>();
builder.Services.AddScoped<ICartService, HttpCartService>();
builder.Services.AddScoped<IItemService, HttpItemService>();
builder.Services.AddScoped<ICategoryService, HttpCategoryService>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite( "Data Source=E:\\SEP3\\Project\\SourceCode\\SEP3_CSharp\\DatabaseConnection\\database.db"));


builder.Services.AddRazorComponents().AddInteractiveServerComponents();



builder.Services.AddAuthorizationCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (! app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
}
var directory = Path.Combine(AppContext.BaseDirectory, "DatabaseConnection");
if (!Directory.Exists(directory))
{
    Directory.CreateDirectory(directory);
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
