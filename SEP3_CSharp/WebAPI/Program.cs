using DatabaseConnection;
using Microsoft.EntityFrameworkCore;
//using RepositoryContracts.CartContracts;
using RepositoryContracts.CategoryContracts;
using RepositoryContracts.ItemContracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        "Data Source=C:\\Users\\user\\Jupiter\\SEP3\\SEP3_CSharp\\DatabaseConnection\\database.db"));

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();