using BlazorApp1.Components;
using Grpc.Net.Client;
using Managers;
using SourceCode;


//using var channel = GrpcChannel.ForAddress("http://localhost:8080");
//var client = new UserService.UserServiceClient(channel);



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton(channel => GrpcChannel.ForAddress("http://localhost:8080"));
builder.Services.AddScoped<IManager, Manager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
