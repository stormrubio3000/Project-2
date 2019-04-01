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
        [HttpGet("{id}", Name = "GetCampaign")]
        public Campaign Get(int id)
        {
            Campaign campaign = new Campaign();
            
            campaign.CampaignID = id;
            campaign.Name = Repo.GetCampaignById(id).Name;
            
            List<Info> listInfo = new List<Info>();

            foreach (var item in Repo.GetAllInfos(id))
            {
                Info info = new Info();
                info.InfoID = item.InfoID;
                info.Type = item.Type;
                info.Message = item.Message;
                info.CampaignID = item.CampaignID;
                listInfo.Add(info);
            }

            campaign.Infos = listInfo;

            return campaign;
        }

        // POST: api/Campaign
        [HttpPost]
		[ProducesResponseType(typeof(Campaign), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public void Post([FromBody] CampaignCreate value)
        {
			Repo.CreateCampaign(value);
			Repo.Save();
        }

        [HttpPost("CreateInfo")]
        public void Post([FromBody] Info info)
        {
            Repo.CreateInfo(info);
            Repo.Save();
        }
    }
}
