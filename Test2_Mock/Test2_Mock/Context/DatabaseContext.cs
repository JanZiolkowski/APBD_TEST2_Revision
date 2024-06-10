using Microsoft.EntityFrameworkCore;
using Test2_Mock.Configurations;
using Test2_Mock.Entities;

namespace Test2_Mock.Context;

public class DatabaseContext : DbContext
{
    public DbSet<ClientCategory> ClientCategories { get; set; }
    public DbSet<BoatStandard> BoatStandards { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Sailboat> Sailboats { get; set; }
    
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
        
        modelBuilder.ApplyConfiguration(new ClientConf());
        modelBuilder.ApplyConfiguration(new BoatStandardConf());
        modelBuilder.ApplyConfiguration(new SailboatConf());
        modelBuilder.ApplyConfiguration(new ReservationConf());
        modelBuilder.ApplyConfiguration(new SailboatReservationConf());
        modelBuilder.Entity<ClientCategory>().ToTable("ClientCategory");
            
            base.OnModelCreating(modelBuilder);
    }
}