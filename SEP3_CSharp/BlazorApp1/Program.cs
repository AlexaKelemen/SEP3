using BlazorApp1.Auth;
using BlazorApp1.Components;
using BlazorApp1.Services;
using BlazorApp1.Services.Contracts;
using Grpc.Net.Client;
using Managers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:8080")
});
builder.Services.AddSingleton(channel => GrpcChannel.ForAddress("http://localhost:8080"));
builder.Services.AddScoped<IManager, Manager>();
builder.Services.AddScoped<IUserService, HttpUserService>();
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthProvider>();
builder.Services.AddScoped<IItemService, HttpItemService>();
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

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
