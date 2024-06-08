using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2_Mock.Entities;

namespace Test2_Mock.Configurations;

public class SailboatReservationConf : IEntityTypeConfiguration<SailboatReservation>
{
    public void Configure(EntityTypeBuilder<SailboatReservation> builder)
    {
        builder.ToTable("Sailboat_Reservation");
        builder.HasKey(x => new { x.IdReservation, x.IdSailboat });
        
        builder
            .HasOne(x => x.Sailboat)
            .WithMany(x => x.SailboatReservations).OnDelete(DeleteBehavior.ClientCascade)
            .HasForeignKey(x => x.IdSailboat);

        builder
            .HasOne(x => x.Reservation)
            .WithMany(x => x.SailboatReservations).OnDelete(DeleteBehavior.ClientCascade)
            .HasForeignKey(x => x.IdReservation);
        //I had to set this DeleteBehavior.ClientCascade because it wouldn't otherwise let me
    }
}