using DigitalMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalMarket.Data.Configurations
{
    public class DigitalCollectionConfiguration : IEntityTypeConfiguration<DigitalCollection>
    {
        public void Configure(EntityTypeBuilder<DigitalCollection> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();

            builder
                .HasMany(x => x.DigitalItems)
                .WithOne(item => item.DigitalCollection)
                .HasForeignKey(item => item.DigitalCollectionId)
                .IsRequired();
        }
    }
}
