using DigitalMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalMarket.Data.Configurations
{
    public class DigitalRarityConfiguration : IEntityTypeConfiguration<DigitalRarity>
    {
        public void Configure(EntityTypeBuilder<DigitalRarity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder
                .HasMany(rarity => rarity.DigitalItems)
                .WithOne(item => item.DigitalRarity)
                .HasForeignKey(item => item.DigitalRarityId);
        }
    }
}
