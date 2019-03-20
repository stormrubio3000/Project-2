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

        public void AddCharacter(Library.Character character)
        {
            _db.Add(Mapper.Map(character));
        }

        public void RemoveCharacter(Library.Character character)
        {
            _db.Remove(Mapper.Map(character));
        }

        //public void CreateCharacter(string name, IEnumerable<int> rolls,
        //                            int raceId, int classId, string bio = null)
        //{
        //    var character = new Library.Character();

        //    character.Name = name;
        //    character.Bio = bio;
        //    character.Experience = 0;
        //    character.Level = 1;

        //    AddCharacter(character);
        //    SetRolls(rolls);
        //    SetRace(raceId);
        //    SetClass(classId);
        //}

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

        public void SetRace(int raceId)
        {
            var character = _db.Character.Last();
            character.RaceId = raceId;

            switch(raceId)
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

        public void SetClass(int classId)
        {
            _db.Character.Last().ClassId = classId;
        }

        public void SetRolls(IEnumerable<int> rolls)
        {
            var character = _db.Character.Last();
            var attributes = rolls.ToList();

            character.Str = attributes[0];
            character.Dex = attributes[1];
            character.Con = attributes[2];
            character.Int = attributes[3];
            character.Wis = attributes[4];
            character.Cha = attributes[5];
        }

        public void SetInitialHp()
        {
            var character = _db.Character.Last();
			//var classhd = _db.GetClass(ID).HD;
			//character.MaxHp = classhd + ConMod;
            // Barbarian
            if (character.ClassId == 1) character.MaxHp = 12;
            // Fighter, Paladin, Ranger
            else if (character.ClassId == 2 || 
                     character.ClassId == 3 ||
                     character.ClassId == 8) character.MaxHp = 10;
            // Bard, Cleric, Druid, Rogue
            else if (character.ClassId == 4 ||
                     character.ClassId == 6 ||
                     character.ClassId == 7 ||
                     character.ClassId == 9) character.MaxHp = 8;
            // Sorcerer, Wizard
            else if (character.ClassId == 5 ||
                     character.ClassId == 10) character.MaxHp = 6;
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
