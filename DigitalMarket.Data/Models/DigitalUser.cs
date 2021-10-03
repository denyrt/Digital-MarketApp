using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DigitalMarket.Data.Models
{
    public class DigitalUser : IdentityUser<Guid>
    {
        public List<DigitalItemInstance> ItemInstances { get; set; }
    }
}
