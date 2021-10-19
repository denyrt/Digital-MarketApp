using DigitalMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalMarket.Data.Configurations
{
    public class DigitalItemConfiguration : IEntityTypeConfiguration<DigitalItem>
    {
        public void Configure(EntityTypeBuilder<DigitalItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ImageUrl).IsRequired(false);
            builder.Property(x => x.MarketName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x => x.DropChance).IsRequired();
            builder.Property(x => x.CreateDateUtc).IsRequired();

            builder
                .HasOne(item => item.DigitalCollection)
                .WithMany(collection => collection.DigitalItems)
                .HasForeignKey(item => item.DigitalCollectionId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasOne(item => item.DigitalRarity)
                .WithMany(rarity => rarity.DigitalItems)
                .HasForeignKey(item => item.DigitalRarityId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasMany(item => item.ItemInstances)
                .WithOne(instance => instance.DigitalItem)
                .HasForeignKey(instance => instance.ItemId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);                
        }
    }
}
