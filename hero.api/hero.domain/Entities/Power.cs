using System;
using System.Collections.Generic;
using Netploy.Common.Base.Entities;

namespace hero.domain.Entities
{
    public class Power: BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<HeroPower> Heroes { get; set; }
    }
}
