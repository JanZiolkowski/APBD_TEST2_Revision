using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2_Mock.Entities;

namespace Test2_Mock.Configurations;

public class BoatStandardConf : IEntityTypeConfiguration<BoatStandard>
{
    public void Configure(EntityTypeBuilder<BoatStandard> builder)
    {
        builder.ToTable("BoatStandard");
        // builder.HasKey(x => x.IdBoatStandard);
        // builder
        //     .Property(x => x.IdBoatStandard)
        //     .ValueGeneratedOnAdd()
        //     .IsRequired();
        // // builder
        // //     .Property(x => x.Name).HasMaxLength(100).IsRequired();
        // // builder
        // //     .Property(x => x.Level).IsRequired();
    }
}