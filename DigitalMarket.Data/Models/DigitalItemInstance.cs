using System;

namespace DigitalMarket.Data.Models
{
    public class DigitalItemInstance
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public DigitalUser Owner { get; set; }
        public Guid ItemId { get; set; }
        public DigitalItem DigitalItem { get; set; }
    }
}
