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
    public class CharacterController : ControllerBase
    {

		public CharacterRepository Repo { get; }
        public UserRepository UserRepo { get; }
		public ItemRepository ItemRepo { get; }

        public CharacterController(CharacterRepository repo, UserRepository userRepo,ItemRepository itemRepo)
		{
			Repo = repo;
            UserRepo = userRepo;
			ItemRepo = itemRepo;
		}


		// GET: api/Character
		[HttpGet]
        public IEnumerable<Character> Get()
        {
			return Repo.GetAllCharacters();

        }

        // GET: api/Character/5
  //      [HttpGet("{id}", Name = "GetCharacter")]
  //      public Character Get(int id)
  //      {
		//	return Repo.GetCharacterById(id);
		//}

        // GET: api/Character/5
        [HttpGet("CharCampUsr/{id}", Name = "CharCampUsr")]
        public IEnumerable<Character> Get(int id,[FromQuery] string username)
        {
            int usrId = UserRepo.GetUserByUsername(username).UserID;
            return Repo.GetCharacterByCampUsr(id, usrId);
        }

		[HttpGet("Inventory/{id}", Name = "CharacterInv")]
		public IEnumerable<Item> GetInv(int id)
		{
			var list = ItemRepo.GetAllInvetories().Where(x => x.CharacterID == id);
			var items = new List<Item>();
			foreach (var item in list)
			{
				items.Add(ItemRepo.GetItemById(item.ItemID));
			}
			return items;
		}

		[HttpPost("Inventory")]
		public void Post([FromBody] Inventory invitem)
		{
			ItemRepo.CreateIventory(invitem);
			ItemRepo.Save();
		}

        [HttpGet("{id}", Name = "CharCamp")]
        public IEnumerable<Character> GetCharCamp(int id)
        {

            return Repo.GetCharacterByCamp(id);
        }

        // POST: api/Character
        [HttpPost]
        public void Post([FromBody] Character value)
        {
			Repo.AddCharacter(value);
			Repo.Save();
        }
    }
}
