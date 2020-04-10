using System;
namespace hero.domain.Entities
{
    public class MissionHero
    {
        public int MissionId { get; set; }
        public Mission Mission { get; set; }
        public int HeroId { get; set; }
        public Hero Hero { get; set; }
    }
}
