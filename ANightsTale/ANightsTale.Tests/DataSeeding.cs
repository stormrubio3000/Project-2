using ANightsTale.DataAccess;
using ANightsTale.DataAccess.Repos;
using ANightsTale.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Tests
{
    class DataSeeding
    {
        private readonly ANightsTaleContext _db;
        private readonly CharacterRepository _repo;
        private readonly CampaignRepository _campRepo;
        private readonly UserRepository _userRepo;

        public DataSeeding(ANightsTaleContext db, CharacterRepository repo)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _repo = repo;
            _campRepo = new CampaignRepository(_db);
            _userRepo = new UserRepository(_db);
        }

        public void SeedCharacterSupportClasses()
        {
            Library.Users user = new Library.Users
            {
                Username = "Test",
                Password = "Test",
                Permission = 0,
                Email = "test@test.com"
            };
            _userRepo.CreateUser(user);
            _userRepo.Save();

            Library.Campaign camp = new Library.Campaign
            {
                Name = "TestCamp",
            };
            _campRepo.CreateCampaign(camp);
            _campRepo.Save();

            Library.Class testClass = new Library.Class
            {
                Name = "TestClass"
            };
            _repo.AddClass(testClass);
            _repo.Save();

            Library.Race race = new Library.Race
            {
                Name = "TestRace"
            };
            _repo.AddRace(race);
            _repo.Save();
        }

        public Library.Character SeedCharacter()
        {
            var character = new Library.Character
            {
                Name = "Test",
                Bio = "Stuff",
                CampaignID = 1,
                UserId = 1,
                RaceID = 1,
                ClassID = 1,
                Experience = 0,
                Level = 1,
                Str = 1,
                Dex = 8,
                Con = 12,
                Int = 15,
                Wis = 11,
                Cha = 5,
                Speed = 1,
                MaxHP = 1
            };


            return character;
        }

        public Library.CharStats SeedCharStats(Library.Character character)
        {
            var stats = new Library.CharStats
            {
                CharacterID = 1,
                HP = character.MaxHP,
                AC = 16,
                PB = 2,
                Gold = 0,
                STR_Mod = -5,
                DEX_Mod = -1,
                CON_Mod = 1,
                INT_Mod = 2,
                WIS_Mod = 0,
                CHA_Mod = -3
            };


            return stats;
        }

        public void SeedClass(int val)
        {
            for (int i = 0; i < val; i++)
            {
                Library.Class testClass = new Library.Class
                {
                    Name = "TestClass"
                };
                _repo.AddClass(testClass);
                _repo.Save();
            }
        }

        public void SeedRace(int val)
        {
            for (int i = 0; i < val; i++)
            {
                Library.Race race = new Library.Race
                {
                    Name = "TestRace"
                };
                _repo.AddRace(race);
                _repo.Save();
            }

        }
    }
}
