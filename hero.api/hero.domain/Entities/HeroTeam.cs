using System;
namespace hero.domain.Entities
{
    public class HeroTeam
    {
        public int HeroId { get; set; }
        public Hero Hero { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
