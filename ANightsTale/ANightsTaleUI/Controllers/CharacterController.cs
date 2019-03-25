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

        public CharacterController(CharacterRepository repo, UserRepository userRepo)
		{
			Repo = repo;
            UserRepo = userRepo;
		}


		// GET: api/Character
		[HttpGet]
        public IEnumerable<Character> Get()
        {
			return Repo.GetAllCharacters();

        }

        // GET: api/Character/5
        [HttpGet("{id}", Name = "GetCharacter")]
        public Character Get(int id)
        {
			return Repo.GetCharacterById(id);
		}

        // GET: api/Character/5
        [HttpGet("CharCampUsr/{id}/{username}", Name = "CharCampUsr")]
        public IEnumerable<Character> Get(int id,string username)
        {
            int usrId = UserRepo.GetUserByUsername(username).UserID;
            return Repo.GetCharacterByCampUsr(id, usrId);
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
