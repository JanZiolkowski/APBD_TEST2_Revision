using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2_Mock.Entities;

namespace Test2_Mock.Configurations;

public class ClientConf : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.IdClient);
        builder.Property(x => x.IdClient).ValueGeneratedOnAdd().IsRequired();
        builder
            .HasOne(x => x.ClientCategory)
            .WithMany(x => x.Clients)
            .HasForeignKey(x => x.IdClientCategory);
    }
}