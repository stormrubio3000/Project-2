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
        public CampaignRepository CampRepo { get; }
        public ItemRepository ItemRepo { get; }

        public CharacterController(CharacterRepository repo, UserRepository userRepo,ItemRepository itemRepo, CampaignRepository campRepo)
		{
			Repo = repo;
            UserRepo = userRepo;
			ItemRepo = itemRepo;
            CampRepo = campRepo;
		}


		// GET: api/Character
		[HttpGet]
        public IEnumerable<Character> Get()
        {
			return Repo.GetAllCharacters();

        }

        // GET: api/Character/GetCharacter/5
        [HttpGet("GetCharacter/{id}", Name = "GetCharacter")]
        public Models.Character Get(int id)
        {
            Models.Character character = new Models.Character();
            character.CharacterID = Repo.GetCharacterById(id).CharacterID;
            character.Name = Repo.GetCharacterById(id).Name;
            character.Bio = Repo.GetCharacterById(id).Bio;
            character.Race = Repo.GetRaceById(Repo.GetCharacterById(id).RaceID).Name;
            character.Class = Repo.GetClassById(Repo.GetCharacterById(id).ClassID).Name;
            character.CampaignName = CampRepo.GetCampaignById(Repo.GetCharacterById(id).CampaignID).Name;
            character.Experience = Repo.GetCharacterById(id).Experience;
            character.Level = Repo.GetCharacterById(id).Level;
            character.Str = Repo.GetCharacterById(id).Str;
            character.Dex = Repo.GetCharacterById(id).Dex;
            character.Con = Repo.GetCharacterById(id).Con;
            character.Int = Repo.GetCharacterById(id).Int;
            character.Wis = Repo.GetCharacterById(id).Cha;
            character.Speed = Repo.GetCharacterById(id).Speed;
            character.MaxHP = Repo.GetCharacterById(id).MaxHP;

            return character;
        }

        // GET: api/Character/5
        [HttpGet("CharCampUsr/{id}", Name = "CharCampUsr")]
        public IEnumerable<Models.Character> Get(int id,[FromQuery] string username)
        {
            List<Models.Character> characters = new List<Models.Character>();
            int usrId = UserRepo.GetUserByUsername(username).UserID;
            foreach (var item in Repo.GetCharacterByCampUsr(id, usrId))
            {
                Models.Character character = new Models.Character();
                character.CharacterID = item.CharacterID;
                character.Name = item.Name;
                character.Bio = item.Bio;
                character.Race = Repo.GetRaceById(item.RaceID).Name;
                character.Class = Repo.GetClassById(item.ClassID).Name;
                character.CampaignName = CampRepo.GetCampaignById(item.CampaignID).Name;
                character.Experience = item.Experience;
                character.Level = item.Level;
                character.Str = item.Str;
                character.Dex = item.Dex;
                character.Con = item.Con;
                character.Int = item.Int;
                character.Wis = item.Cha;
                character.Speed = item.Speed;
                character.MaxHP = item.MaxHP;
                characters.Add(character);
            }
            return characters;
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
        public IEnumerable<Models.Character> GetCharCamp(int id)
        {
            List<Models.Character> characters = new List<Models.Character>();
            foreach (var item in Repo.GetCharacterByCamp(id))
            {
                Models.Character character = new Models.Character();
                character.CharacterID = item.CharacterID;
                character.Name = item.Name;
                character.Bio = item.Bio;
                character.Race = Repo.GetRaceById(item.RaceID).Name;
                character.Class = Repo.GetClassById(item.ClassID).Name;
                character.CampaignName = CampRepo.GetCampaignById(item.CampaignID).Name;
                character.Experience = item.Experience;
                character.Level = item.Level;
                character.Str = item.Str;
                character.Dex = item.Dex;
                character.Con = item.Con;
                character.Int = item.Int;
                character.Wis = item.Cha;
                character.Speed = item.Speed;
                character.MaxHP = item.MaxHP;
                characters.Add(character);
            }
            return characters;
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
