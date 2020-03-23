using System;
using System.ComponentModel.DataAnnotations;

namespace hero.aplication.DTOs.Inputs.Hero
{
    public class AddHeroInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SuperPower { get; set; }
    }
}
