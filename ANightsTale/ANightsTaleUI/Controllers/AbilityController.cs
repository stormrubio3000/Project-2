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
    public class AbilityController : ControllerBase
    {


		public AbilityRepository Repo { get; }

		public AbilityController(AbilityRepository repo)
		{
			Repo = repo;
		}


		// GET: api/Ability
		[HttpGet]
        public IEnumerable<Abilities> Get()
        {
			return Repo.GetAllAbilities();
        }

        // GET: api/Ability/5
        [HttpGet("{id}", Name = "Get")]
        public Abilities Get(int id)
        {
			return Repo.GetAbilityById(id);
        }

        // POST: api/Ability
        [HttpPost]
		[ProducesResponseType(typeof(Campaign), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public void Post([FromBody] Abilities value)
        {
			Repo.CreateAbility(value);
			Repo.Save();
        }
    }
}
