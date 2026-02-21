using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Core.Dal;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
{
    private const string ConnectionString = "Server=localhost;Port=5432;Database=rdbank-db;User Id=postgres;Password=postgres";

    public AuthDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AuthDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);

        return new AuthDbContext(optionsBuilder.Options);
    }
}
