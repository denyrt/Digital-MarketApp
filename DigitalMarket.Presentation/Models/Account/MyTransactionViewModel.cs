using System;

namespace DigitalMarket.Presentation.Models.Account
{
    public record MyTransactionViewModel
    {
        public Guid Id { get; init; }
        public TransactionType TransactionType { get; init; }
        public Guid FromUser { get; init; }
        public Guid ToUser { get; init; }
        public Guid InstanceId { get; init; }
        public double Payment { get; init; }
        public DateTime CreateDateUtc { get; init; }
    }

    public enum TransactionType
    {
        None = 0,
        Sell,
        Bought,
        Drop
    }
}
