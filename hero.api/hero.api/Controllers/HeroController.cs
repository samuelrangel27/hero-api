using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hero.api.Results;
using hero.aplication.Services.Interfaces;
using hero.domain.Entities;
using hero.transversal.Results;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hero.api.Controllers
{
    [Route("api/[controller]")]
    public class HeroController : Controller
    {
        private readonly IHeroApplicationService _heroService;

        public HeroController(IHeroApplicationService heroService)
        {
            this._heroService = heroService;
        }

        /// <summary>
        /// Gets All the heroes from the Justice league
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<ApiResult<IEnumerable<Hero>>> Get()
        {
            return _heroService.GetAll();
        }
        /*

        /// <summary>
        /// Creates a new Hero 
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Hero hero)
        {
            var result = new ApiResult();
            if (!ModelState.IsValid)
            {
                result.Message = "Invalid Hero Information";
                result.IsError = true;
                return BadRequest(result);
            }
                

            dbContext.Heroes.Add(hero);
            dbContext.SaveChanges();
            result.Message = "Everything is ok";
            return Ok(result);
        }

        /// <summary>
        /// Modifies an existing Hero
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put([FromBody] Hero hero)
        {
            var result = new ApiResult();
            if (!ModelState.IsValid)
            {
                result.Message = "Invalid Hero Information";
                result.IsError = true;
                return BadRequest(result);
            }

            var dbHero = dbContext.Heroes
                .Where(h => h.Id == hero.Id)
                .FirstOrDefault();

            if (dbHero == null)
            {
                result.Message = $"Hero with id {hero.Id} not found";
                result.IsError = true;
                return BadRequest(result);
            }
                

            dbHero.Name = hero.Name;
            dbHero.SuperPower = hero.SuperPower;

            dbContext.Update(dbHero);
            dbContext.SaveChanges();

            result.Message = "Everything is ok";
            return Ok(result);
        }

        /// <summary>
        /// Removes a hero from Justice league
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var result = new ApiResult();
            if (!ModelState.IsValid)
            {
                result.Message = "Invalid Hero Information";
                result.IsError = true;
                return BadRequest(result);
            }

            var dbHero = dbContext.Heroes
                .Where(h => h.Id == id)
                .FirstOrDefault();

            if (dbHero == null)
            {
                result.Message = $"Hero with id {id} not found";
                result.IsError = true;
                return BadRequest(result);
            }

            dbContext.Remove(dbHero);
            dbContext.SaveChanges();

            result.Message = "Everything is ok";
            return Ok(result);
        }
        */


    }
}
