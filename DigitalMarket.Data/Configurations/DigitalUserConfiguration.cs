using DigitalMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalMarket.Data.Configurations
{
    internal class DigitalUserConfiguration : IEntityTypeConfiguration<DigitalUser>
    {
        public void Configure(EntityTypeBuilder<DigitalUser> builder)
        {
            builder
                .HasMany(x => x.ItemInstances)
                .WithOne(item => item.Owner)
                .HasForeignKey(item => item.OwnerId)
                .IsRequired();
        }
    }
}
