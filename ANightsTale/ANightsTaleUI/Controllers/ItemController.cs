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
    public class ItemController : ControllerBase
    {
		public ItemRepository Repo { get; }

		public ItemController(ItemRepository repo)
		{
			Repo = repo;
		}


		// GET: api/Items
		[HttpGet]
        public IEnumerable<Item> Get()
        {
			return Repo.GetAllItems();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
			return Repo.GetItemById(id);
        }

        // POST: api/Items
        [HttpPost]
		[ProducesResponseType(typeof(Campaign), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public void Post([FromBody] Item value)
        {
			Repo.CreateItem(value);
			Repo.Save();
        }
    }
}
