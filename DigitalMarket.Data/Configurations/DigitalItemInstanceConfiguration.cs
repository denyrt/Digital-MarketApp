using DigitalMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalMarket.Data.Configurations
{
    public class DigitalItemInstanceConfiguration : IEntityTypeConfiguration<DigitalItemInstance>
    {
        public void Configure(EntityTypeBuilder<DigitalItemInstance> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.DigitalItem)
                .WithMany(item => item.ItemInstances)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasOne(x => x.Owner)
                .WithMany(user => user.ItemInstances)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
