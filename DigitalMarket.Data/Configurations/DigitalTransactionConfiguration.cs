using DigitalMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalMarket.Data.Configurations
{
    public class DigitalTransactionConfiguration : IEntityTypeConfiguration<DigitalTransaction>
    {
        public void Configure(EntityTypeBuilder<DigitalTransaction> builder)
        {
            builder.HasKey(x => x.Id);
 
            builder
                .HasOne(x => x.ItemInstance)
                .WithMany(instance => instance.Transactions)
                .HasForeignKey(x => x.InstanceId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasOne(x => x.FromUser)
                .WithMany(user => user.OutputTransactions)
                .HasForeignKey(x => x.FromUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasOne(x => x.ToUser)
                .WithMany(user => user.InputTransactions)
                .HasForeignKey(x => x.ToUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}