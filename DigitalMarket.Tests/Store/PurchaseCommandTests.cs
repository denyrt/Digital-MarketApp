using DigitalMarket.Application.Models;
using DigitalMarket.Application.Services;
using DigitalMarket.BisunessLogic.Commands.Store;
using DigitalMarket.Data.Contexts;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using DigitalMarket.Tests.Database;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace DigitalMarket.Tests.Store
{
    internal class PurchaseCommandTests
    {
        [Test]
        public async Task PurchaseSuccessCase()
        {
            var dbContext = await Extensions.CreateAndSeedInMemoryDatabase();
            var storeService = new StoreService(dbContext);
            var purchaseCommandHandler = new PurchaseCommandHandler(dbContext, storeService);
            var command = new PurchaseCommand
            {
                BuyerId = Guid.Parse("A0634AA1-D47C-428A-986A-7C3AB0541211"),
                CollectionId = Guid.Parse("0F3D0FF7-8AC8-4FED-A1D5-592AFBCAB654")
            };
            
            var response = await purchaseCommandHandler.Handle(command, default);
            
            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Code, ResponseCodes.Ok);
        }

        [Test]
        public async Task PurchaseLowBalanceFailureCase()
        {
            var dbContext = await Extensions.CreateAndSeedInMemoryDatabase();
            var storeService = new StoreService(dbContext);
            var purchaseCommandHandler = new PurchaseCommandHandler(dbContext, storeService);
            var command = new PurchaseCommand
            {
                BuyerId = Guid.Parse("4DBA2DB9-CA70-4384-85FB-C86A82EE1A41"),
                CollectionId = Guid.Parse("0F3D0FF7-8AC8-4FED-A1D5-592AFBCAB654")
            };
            
            var response = await purchaseCommandHandler.Handle(command, default);
            
            Assert.AreEqual(response.Code, PurchaseMessages.LowBalance);
        }
    }
}
