using System;
using System.Collections.Generic;
using Netploy.Common.Base.Entities;

namespace hero.domain.Entities
{
    public enum TeamType
    {
        Action,
        Teaching
    }

    public class Team : BaseEntity<int>
    {
        public string Name { get; set; }
        public TeamType Type { get; set; }
        public IEnumerable<HeroTeam> Members { get; set; }
    }
}
