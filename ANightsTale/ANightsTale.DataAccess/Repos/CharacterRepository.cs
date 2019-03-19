using System;
using System.Collections.Generic;
using System.Linq;
using ANightsTale.Library;
using ANightsTale.Library.Interfaces;

namespace ANightsTale.DataAccess.Repos
{
	public class CharacterRepository : ICharacterRepository
    {

        private readonly ANightsTaleContext _db;
        private static Random rand = new Random();

        public CharacterRepository(ANightsTaleContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void CreateCharacter(Library.Character character)
        {
            _db.Add(Mapper.Map(character));
        }

        public void DeleteCharacter(Library.Character character)
        {
            _db.Remove(Mapper.Map(character));
        }

        public IEnumerable<Library.Character> GetAllCharacters()
        {        
            return Mapper.Map(_db.Character);
        }

        public Library.Character GetCharacterById(int id)
        {
            return Mapper.Map(_db.Character.First(c => c.CharacterId == id));
        }

        public Library.Character GetCharacterByName(string name)
        {
            return Mapper.Map(_db.Character.First(c => c.Name.Equals(name)));
        }

        public void SetRace(Library.Race r)
        {
            var character = _db.Character.Last();
            character.RaceId = r.RaceID;

            switch(r.RaceID)
            {
                case 1:
                    //Dwarf
                    character.Speed = 20;
                    break;
                case 2:
                    //Human
                    character.Speed = 30;
                    break;
                case 3:
                    //Elf
                    character.Speed = 30;
                    break;
                case 4:
                    //Halfling
                    character.Speed = 20;
                    break;
                case 5:
                    //Gnomes
                    character.Speed = 20;
                    break;
                case 6:
                    //Half-Orc
                    character.Speed = 30;
                    break;
                default:
                    break;
            }
        }

        public void SetClass(Library.Class c)
        {
            _db.Character.Last().ClassId = c.ClassID;
        }

        public void SetRolls(IEnumerable<int> rolls, int id)
        {
            var character = _db.Character.First(c => c.CharacterId == id);
            var attributes = rolls.ToList();

            character.Str = attributes[0];
            character.Dex = attributes[1];
            character.Con = attributes[2];
            character.Int = attributes[3];
            character.Wis = attributes[4];
            character.Cha = attributes[5];
        }

        public IEnumerable<int> InitialRolls()
        {
            List<int> rolls = new List<int>();
            List<int> totals = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    rolls.Add(rand.Next(1, 7));
                }

                rolls.OrderByDescending(o => o);
                rolls.Remove(rolls.Last());

                totals.Add(rolls[0] + rolls[1] + rolls[2]);

                rolls.Clear();
            }

            return totals;
        }

        public void CalculateModifiers(int id)
        {
            throw new NotImplementedException();
        }

        public void CalculateSavingThrows(int id)
        {
            throw new NotImplementedException();
        }

        public void CalculateSkills(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
