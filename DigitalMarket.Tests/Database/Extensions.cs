using DigitalMarket.Data.Contexts;
using DigitalMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DigitalMarket.Tests.Database
{
    internal static class Extensions
    {
        public static async Task<DigitalMarketDbContext> CreateAndSeedInMemoryDatabase()
        {
            var dbContextOptions = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DigitalMarketDbContext(dbContextOptions);

            await dbContext.SeedRoles();
            await dbContext.SeedUsers();
            await dbContext.SeedRarities();
            await dbContext.SeedCollections();
            await dbContext.SeedItems();
            await dbContext.SaveChangesAsync();

            return dbContext;
        }

        private static async Task SeedRoles(this DigitalMarketDbContext dbContext)
        {
            await dbContext.Roles.AddRangeAsync(new DigitalRole[]
            {
                new()
                {
                    Id = Guid.Parse("18612AB7-F1DD-4A79-908F-9D1E487BA3C2"),
                    Name = "User"
                },
                new()
                {
                    Id = Guid.Parse("9233A0BC-6BBA-4E6E-A919-7A97EC081E93"),
                    Name = "Admin"
                }
            });
        }

        private static async Task SeedUsers(this DigitalMarketDbContext dbContext)
        {
            await dbContext.Users.AddRangeAsync(new DigitalUser[]
            {
                new()
                {
                    Id = Guid.Parse("A0634AA1-D47C-428A-986A-7C3AB0541211"),
                    UserName = "TestUser1",
                    Balance = 100d
                },
                new()
                {
                    Id = Guid.Parse("4DBA2DB9-CA70-4384-85FB-C86A82EE1A41"),
                    UserName = "TestUser2",
                    Balance = 10d
                }
            });
        }

        private static async Task SeedRarities(this DigitalMarketDbContext dbContext)
        {
            await dbContext.DigitalRarities.AddRangeAsync(new DigitalRarity[]
            {
                new()
                {
                    Id = Guid.Parse("35A13334-9F93-42AF-B1E2-AEE499D63253"),
                    Name = "Common"
                }
            });
        }

        private static async Task SeedCollections(this DigitalMarketDbContext dbContext)
        {
            await dbContext.DigitalCollections.AddRangeAsync(new DigitalCollection[]
            {
                new DigitalCollection
                {
                    Id = Guid.Parse("0F3D0FF7-8AC8-4FED-A1D5-592AFBCAB654"),
                    Description = "TestDescription1",
                    Name = "TestBox1",
                    Price = 50d,
                    AvailableAtMarket = true
                }
            });
        }

        private static async Task SeedItems(this DigitalMarketDbContext dbContext)
        {
            await dbContext.DigitalItems.AddRangeAsync(new DigitalItem[]
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    MarketName = "TestItem1",
                    DigitalCollectionId = Guid.Parse("0F3D0FF7-8AC8-4FED-A1D5-592AFBCAB654"),
                    Description = "TestItemDescription",
                    DigitalRarityId = Guid.Parse("35A13334-9F93-42AF-B1E2-AEE499D63253"),
                    DropChance = 100,
                    CreateDateUtc = DateTime.Now,
                    ImageUrl = string.Empty
                }
            });
        }
    }
}
