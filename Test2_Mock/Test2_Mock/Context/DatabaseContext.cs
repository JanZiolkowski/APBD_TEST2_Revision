using Microsoft.EntityFrameworkCore;

namespace Test2_Mock.Context;

public class DatabaseContext : DbContext
{
    //Created two constructor needed for database
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    //TODO: configure here adding all configurations for entities!!
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}