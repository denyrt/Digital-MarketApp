using System;

namespace DigitalMarket.Data.Models
{
    public class DigitalSellOffer
    {
        public Guid Id { get; set; }
        public Guid InstanceId { get; set; }
        public DigitalItemInstance ItemInstance { get; set; }
        public double Price { get; set; }
        public DateTime CreateDateUtc { get; set; }
    }
}