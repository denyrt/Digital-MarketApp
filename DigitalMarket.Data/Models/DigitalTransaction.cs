using System;

namespace DigitalMarket.Data.Models
{
    public class DigitalTransaction
    {
        public Guid Id { get; set; }
        public Guid InstanceId { get; set; }
        public DigitalItemInstance ItemInstance { get; set; }
        public Guid FromUserId { get; set; }
        public DigitalUser FromUser { get; set; }
        public Guid ToUserId { get; set; }
        public DigitalUser ToUser { get; set; }
        public double Price { get; set; }
        public DateTime CreateTimeUtc { get; set; }
    }
}