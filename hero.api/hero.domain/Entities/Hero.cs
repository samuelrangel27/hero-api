using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Netploy.Common.Base.Entities;

namespace hero.domain.Entities
{
    public enum Range
    {
        Trainee,
        Junior,
        Senior,
        Master
    }

    public class Hero : BaseEntity<int>
    {
        [Required]
        public string Name { get; set; }
        public string Alias { get; set; }
        public Range Range { get; set; }
        public IEnumerable<HeroPower> Powers { get; set; }
        public IEnumerable<HeroTeam> Teams { get; set; }

        public int SenseiId { get; set; }
        public Hero Sensei { get; set; }

        public IEnumerable<Hero> Students { get; set; }

        public IEnumerable<MissionHero> Missions { get; set; }
    }
}
