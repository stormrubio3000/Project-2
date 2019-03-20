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

            if (raceId == 1 || raceId == 4 || raceId == 5) character.Speed = 20;
            else character.Speed = 30;
        }

        public void SetClass(int classId)
        {
            _db.Character.Last().ClassId = classId;
            _db.Character.Last().MaxHp = _db.Class.First(c => c.ClassId == classId).Hd;
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

        public void SetModifiers()
        {
            var character = _db.Character.Last();
            var stats = _db.CharStats.First(s => s.CharacterId == character.CharacterId);

            stats.StrMod = CalculateModifier(character.Str);
            stats.DexMod = CalculateModifier(character.Dex);
            stats.ConMod = CalculateModifier(character.Con);
            stats.IntMod = CalculateModifier(character.Int);
            stats.WisMod = CalculateModifier(character.Wis);
            stats.ChaMod = CalculateModifier(character.Cha);
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

        public int CalculateModifier(int val)
        {
            if (val == 1) return -5;
            else if (val == 2 || val == 3) return -4;
            else if (val == 4 || val == 5) return -3;
            else if (val == 6 || val == 7) return -2;
            else if (val == 8 || val == 9) return -1;
            else if (val == 10 || val == 11) return 0;
            else if (val == 12 || val == 13) return 1;
            else if (val == 14 || val == 15) return 2;
            else if (val == 16 || val == 17) return 3;
            else if (val == 18 || val == 19) return 4;
            else if (val == 20 || val == 21) return 5;

            return 0;
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
