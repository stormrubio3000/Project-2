using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANightsTale.DataAccess.Repos;
using ANightsTale.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANightsTaleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharAbilityController : ControllerBase
    {


		public AbilityRepository Repo { get; }

		public CharAbilityController(AbilityRepository repo)
		{
			Repo = repo;
		}


        // GET: api/CharAbility/5
        [HttpGet("{id}", Name = "Get")]
        public List<Abilities> Get(int id)
        {
			var list = Repo.GetAllCharAbilities().Where(x => x.CharacterId == id);
			var abilities = new List<Abilities>();
			foreach (var item in list)
			{
				abilities.Add(Repo.GetAbilityById(item.AbilityId));
			}
			return abilities;
		}

        // POST: api/CharAbility
        [HttpPost]
        public void Post([FromBody] CharAbilities value)
        {
			Repo.CreateCharAbilities(value);
			Repo.Save();
        }
    }
}
