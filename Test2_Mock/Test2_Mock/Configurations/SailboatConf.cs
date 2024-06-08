using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2_Mock.Entities;

namespace Test2_Mock.Configurations;

public class SailboatConf : IEntityTypeConfiguration<Sailboat>
{
    public void Configure(EntityTypeBuilder<Sailboat> builder)
    {
        //builder.ToTable("Sailboat");
        builder.HasKey(x => x.IdSailboat);
        builder
            .Property(x => x.IdSailboat)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder
            .Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder
            .Property(x => x.Capacity).IsRequired();
        builder
            .Property(x => x.Description).HasMaxLength(100).IsRequired();
        builder
            .Property(x => x.Price).IsRequired();
        builder
            .HasOne(x => x.BoatStandard)
            .WithMany(x => x.SailBoats)
            .HasForeignKey(x => x.IdBoatStandard);

    }
}