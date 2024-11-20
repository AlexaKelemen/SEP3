using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection;

public class AppContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlite("Data Source=database.db");
    }
}