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
    public class CampaignController : ControllerBase
    {


		public CampaignRepository Repo { get; }

		public CampaignController(CampaignRepository repo)
		{
			Repo = repo;
		}


		// GET: api/Campaign
		[HttpGet]
        public IEnumerable<Campaign> Get()
        {
			return Repo.GetAllCampaigns();
        }

        // GET: api/Campaign/5
        [HttpGet("{id}", Name = "Get")]
        public Campaign Get(int id)
        {
			return Repo.GetCampaignById(id);
        }

        // POST: api/Campaign
        [HttpPost]
		[ProducesResponseType(typeof(Campaign), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public void Post([FromBody] Campaign value)
        {
			Repo.CreateCampaign(value);
			Repo.Save();
        }
    }
}
