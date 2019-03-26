﻿using System;
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

        public CharacterController(CharacterRepository repo, UserRepository userRepo, CampaignRepository campRepo)
		{
			Repo = repo;
            UserRepo = userRepo;
            CampRepo = campRepo;
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
        public IEnumerable<Models.Character> Get(int id,[FromQuery] string username)
        {
            List<Models.Character> characters = new List<Models.Character>();
            int usrId = UserRepo.GetUserByUsername(username).UserID;
            foreach (var item in Repo.GetCharacterByCampUsr(id, usrId))
            {
                Models.Character character = new Models.Character();
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

        [HttpGet("{id}", Name = "CharCamp")]
        public IEnumerable<Models.Character> GetCharCamp(int id)
        {
            List<Models.Character> characters = new List<Models.Character>();
            foreach (var item in Repo.GetCharacterByCamp(id))
            {
                Models.Character character = new Models.Character();
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
