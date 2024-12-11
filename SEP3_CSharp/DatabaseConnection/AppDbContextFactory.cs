using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DatabaseConnection;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var databasePath = Path.Combine(AppContext.BaseDirectory,
            "..\\..\\..\\..\\DatabaseConnection\\database.db");
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite(
            ("Data Source=C:\\Users\\user\\Jupiter\\SEP3\\SEP3_CSharp\\DatabaseConnection\\database.db"));


        return new AppDbContext(optionsBuilder.Options);
    }
}