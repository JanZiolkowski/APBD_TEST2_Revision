using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2_Mock.Entities;

namespace Test2_Mock.Configurations;

public class ReservationConf : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservation");
        builder.HasKey(x => x.IdReservation);
        builder
            .Property(x => x.IdReservation)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder
            .HasOne(x => x.BoatStandard)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.IdBoatStandard);
        builder
            .HasOne(x => x.Client)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.IdClient);
        
        
    }
}