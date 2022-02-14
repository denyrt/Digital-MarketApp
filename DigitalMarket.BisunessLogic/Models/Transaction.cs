using DigitalMarket.Data.Models;
using System;

namespace DigitalMarket.BisunessLogic.Models
{
    public record Transaction
    {
        public Guid Id { get; init; }
        public Guid FromUserId { get; init; }
        public Guid ToUserId { get; init; }
        public Guid InstanceId { get; init; }
        public double Payment { get; init; }
        public DateTime CreateDateUtc { get; init; }
    }

    public static class TransactionMapping
    {
        public static Transaction ToTransaction(this DigitalTransaction digitalTransaction)
        {
            return new()
            {
                Id = digitalTransaction.Id,
                ToUserId = digitalTransaction.ToUserId,
                FromUserId = digitalTransaction.FromUserId,
                Payment = digitalTransaction.Price,
                InstanceId = digitalTransaction.InstanceId,
                CreateDateUtc = digitalTransaction.CreateTimeUtc
            };
        }
    }
}
