using System;
using System.ComponentModel.DataAnnotations;

namespace hero.domain.Entities
{
    public class Hero : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SuperPower { get; set; }
        public Hero()
        {
        }
    }
}
