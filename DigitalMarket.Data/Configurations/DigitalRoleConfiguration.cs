using System;
using DigitalMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalMarket.Data.Configurations
{
    internal class DigitalRoleConfiguration : IEntityTypeConfiguration<DigitalRole>
    {
        public void Configure(EntityTypeBuilder<DigitalRole> builder)
        {
            builder.HasData(new DigitalRole[]
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "User",
                    NormalizedName = "USER"
                }
            });
        }
    }
}