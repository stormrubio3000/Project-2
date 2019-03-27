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
    public class CharFeatsController : ControllerBase
    {

		public AbilityRepository Repo { get; }

		public CharFeatsController(AbilityRepository repo)
		{
			Repo = repo;
		}
        // GET: api/CharFeats/5
        [HttpGet("{id}", Name = "Get")]
        public List<Feats> Get(int id)
        {
			var list = Repo.GetAllCharFeats().Where(x => x.CharacterId == id);
			var feats = new List<Feats>();
			foreach (var item in list)
			{
				feats.Add(Repo.GetFeatById(item.CharacterId));
			}
			return feats;
		}

        // POST: api/CharFeats
        [HttpPost]
        public void Post([FromBody] CharFeats value)
        {
			Repo.CreateCharFeat(value);
			Repo.Save();
		}
    }
}
