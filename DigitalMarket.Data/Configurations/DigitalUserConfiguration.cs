using DigitalMarket.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalMarket.Data.Configurations
{
    internal class DigitalUserConfiguration : IEntityTypeConfiguration<DigitalUser>
    {
        private readonly IPasswordHasher<DigitalUser> _passwordHasher;

        public DigitalUserConfiguration(IPasswordHasher<DigitalUser> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        
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