using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using System;

namespace DigitalMarket.BisunessLogic.Queries.Marketplace
{
    public record GetInstanceResponse : ResponseBase<GetInstanceResponse>
    {
        public Guid InstanceId { get; init; }
        public string OwnerName { get; init; }
        public SellOffer? SellOffer { get; init; }
        public Item Item { get; init; }
        public Transaction[] LastTransactions { get; init; }
    }
}
