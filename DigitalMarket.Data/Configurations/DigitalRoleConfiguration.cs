using DigitalMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalMarket.Data.Configurations
{
    internal class DigitalRoleConfiguration : IEntityTypeConfiguration<DigitalRole>
    {
        public void Configure(EntityTypeBuilder<DigitalRole> builder)
        {
            
        }
    }
}