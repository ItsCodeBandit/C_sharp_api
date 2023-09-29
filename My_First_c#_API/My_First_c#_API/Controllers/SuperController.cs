using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace My_First_c__API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperController : ControllerBase
    {
        private static List<Super> heroes = new List<Super>
            {
                new Super { Id = 1,
                    Name = "Batman",
                    FirstName = "Bruce",
                    LastName = "Wanye",
                    Place = "Gotham City"
                },
                new Super { Id = 2,
                    Name = "superman",
                    FirstName = "Clark",
                    LastName = "Kent",
                    Place = "Metropolis"
                }

            };

        [HttpGet]
        public async Task<ActionResult<List<Super>>> Get()
        {

            return Ok(heroes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Super>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero Not Found.");
            return Ok(hero);
        }


        [HttpPost]

        public async Task<ActionResult<List<Super>>> Addhero(Super hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<Super>>> updatehero(Super request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
                return BadRequest("Hero Not Found.");
            hero.Name = request.Name;  
            hero.FirstName = request.FirstName;     
            hero.LastName = request.LastName; 
            hero.Place = request.Place;
            

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Super>>>Delete(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero Not Found.");
            heroes.Remove(hero);
            return Ok(heroes);
        }

    }
}
