using DigitalMarket.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace DigitalMarket.Data.Contexts
{
    public class DigitalMarketDbContext : IdentityDbContext<DigitalUser, DigitalRole, Guid>
    {
        public DbSet<DigitalCollection> DigitalCollections { get; set; }
        public DbSet<DigitalItem> DigitalItems { get; set; }
        public DbSet<DigitalItemInstance> DigitalItemInstances { get; set; }
        public DbSet<DigitalRarity> DigitalRarities { get; set; }

        public DigitalMarketDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}