using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DigitalMarket.Data.Models
{
    public class DigitalUser : IdentityUser<Guid>
    {
        public double Balance { get; set; }
        public List<DigitalTransaction> OutputTransactions { get; set; }
        public List<DigitalTransaction> InputTransactions { get; set; }
        public List<DigitalItemInstance> ItemInstances { get; set; }
    }
}
