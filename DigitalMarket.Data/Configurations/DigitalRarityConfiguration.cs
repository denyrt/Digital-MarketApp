using DigitalMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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
                .HasForeignKey(item => item.DigitalRarityId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasData(new DigitalRarity[]
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Common"
                },

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rare"
                },

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Super Rare"
                },

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Epic"
                },

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Legendary"
                }
            });
        }
    }
}
