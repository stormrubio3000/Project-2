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
    public class FeatController : ControllerBase
    {

		public AbilityRepository Repo { get; }

		public FeatController(AbilityRepository repo)
		{
			Repo = repo;
		}


		// GET: api/Feat
		[HttpGet]
        public IEnumerable<Feats> Get()
        {
			return Repo.GetAllFeats();
        }

        // GET: api/Feat/5
        [HttpGet("{id}", Name = "Get")]
        public Feats Get(int id)
        {
			return Repo.GetFeatById(id);
        }

        // POST: api/Feat
        [HttpPost]
		[ProducesResponseType(typeof(Campaign), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public void Post([FromBody] Feats value)
        {
			Repo.CreateFeat(value);
			Repo.Save();
        }
    }
}
