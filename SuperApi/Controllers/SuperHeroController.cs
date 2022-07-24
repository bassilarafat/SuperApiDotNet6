using Microsoft.AspNetCore.Mvc;

namespace SuperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : Controller
    {
        private static List<SuperHero> heros = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
            Name = "spiderman",
            FirstName = "peter",
            LastName = "parker",
            Place = "NYC"

            },
            new SuperHero
            {
                 Id = 2,
            Name = "IronMAn",
            FirstName = "peter",
            LastName = "parker",
            Place = "NYC"


            }

        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {

            return Ok(heros);
        }
        //to get one hero
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heros.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero id not found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heros.Add(hero);
            return Ok(heros);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> editHero(SuperHero hero)
        {
            var Newhero = heros.Find(h => h.Id == hero.Id);
            if (Newhero == null)
                return BadRequest("not found");
            //we can use instead automapper

            Newhero.FirstName = hero.FirstName;
            Newhero.Name = hero.Name;
            Newhero.LastName = hero.LastName;
            Newhero.Place = hero.Place;


            return Ok(Newhero);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> Delete(int id)
        {
            var Newhero = heros.Find(h => h.Id == id);
            if (Newhero == null)
                return BadRequest("not found");
            heros.Remove(Newhero);
            return Ok(heros);

        }
    }
}
