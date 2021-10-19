using DigitalMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalMarket.Data.Configurations
{
    public class DigitalSellOfferConfiguration : IEntityTypeConfiguration<DigitalSellOffer>
    {
        public void Configure(EntityTypeBuilder<DigitalSellOffer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.CreateDateUtc).IsRequired();

            builder
                .HasOne(x => x.ItemInstance)
                .WithOne(x => x.DigitalSellOffer)
                .HasForeignKey<DigitalSellOffer>(x => x.InstanceId);
        }
    }
}
