using Microsoft.EntityFrameworkCore;
using Test2_Mock.Configurations;
using Test2_Mock.Entities;

namespace Test2_Mock.Context;

public class DatabaseContext : DbContext
{
    public DbSet<ClientCategory> ClientCategories;
    public DbSet<BoatStandard> BoatStandards;
    public DbSet<Client> Clients;
    public DbSet<Reservation> Reservations;
    public DbSet<Sailboat> Sailboats;
    
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
        modelBuilder.ApplyConfiguration(new ClientConf());
        modelBuilder.ApplyConfiguration(new SailboatConf());
        modelBuilder.ApplyConfiguration(new ReservationConf());
        modelBuilder.ApplyConfiguration(new BoatStandardConf());
        modelBuilder.ApplyConfiguration(new SailboatReservationConf());
    }
}