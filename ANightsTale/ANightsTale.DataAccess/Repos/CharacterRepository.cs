using System;
using System.Collections.Generic;
using System.Linq;
using ANightsTale.Library;
using ANightsTale.Library.CharacterLogic;
using ANightsTale.Library.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ANightsTale.DataAccess.Repos
{
	public class CharacterRepository : ICharacterRepository
    {

        private readonly ANightsTaleContext _db;

        public CharacterRepository(ANightsTaleContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void CreateCharacter(Library.Character character, IEnumerable<int> skills)
        {
            var skillManager = new SkillManager();
            var modManager = new ModifierManager();

            SetSpeed(character);
            SetMaxHp(character);

            var stats = new Library.CharStats();
            stats.CharacterID = character.CharacterID;
            stats.HP = character.MaxHP;
            stats.PB = 2;

            modManager.SetModifiers(character, stats);
            SetSavingThrows(character, stats);
            skillManager.SetSkills(stats);
            skillManager.UpdateSkills(skills.ToList(), stats);

            AddCharacter(character);
            Save();

            AddCharStats(stats);
            Save();
        }

        public void AddCharacter(Library.Character character)
        {
            if (character != null) { _db.Add(Mapper.Map(character)); }
            else { throw new ArgumentNullException(); }
        }

        public void RemoveCharacter(int id)
        {
            if (_db.Character.Any(c => c.CharacterId == id)) { _db.Remove(_db.Character.Find(id)); }
            else { throw new ArgumentNullException(); }
        }

        public void AddCharStats(Library.CharStats stats)
        {
            stats.CharacterID = _db.Character.Last().CharacterId;

            _db.Add(Mapper.Map(stats));

        }

        public void RemoveCharStats(int id)
        {
            if (_db.CharStats.Any(c => c.Id == id)) { _db.Remove(_db.CharStats.Find(id)); }
            else { throw new ArgumentNullException(); }
        }

        public void AddRace(Library.Race race)
        {
            if (race != null) { _db.Add(Mapper.Map(race)); }
            else { throw new ArgumentNullException(); }
        }

        public void RemoveRace(int id)
        {
            if (_db.Race.Any(r => r.RaceId == id)) { _db.Remove(_db.Race.Find(id)); }
            else { throw new ArgumentNullException(); }
        }

        public void AddClass(Library.Class myClass)
        {
            if (myClass != null) { _db.Add(Mapper.Map(myClass)); }
            else { throw new ArgumentNullException(); }
        }

        public void RemoveClass(int id)
        {
            if (_db.Class.Any(c => c.ClassId == id)) { _db.Remove(_db.Class.Find(id)); }
            else { throw new ArgumentNullException(); }
        }

        public IEnumerable<Library.Character> GetAllCharacters()
        {        
            return Mapper.Map(_db.Character);
        }

        public IEnumerable<Library.Race> GetAllRaces()
        {
            return Mapper.Map(_db.Race);
        }

        public IEnumerable<Library.Class> GetAllClasses()
        {
            return Mapper.Map(_db.Class);
        }

        public IEnumerable<Library.Character> GetCharacterByCampUsr(int campId, int usrId)
        {
            return Mapper.Map(_db.Character.Where(c => c.CampaignId == campId && c.UsersId == usrId));
        }

        public IEnumerable<Library.Character> GetCharacterByCamp(int campId)
        {
            return Mapper.Map(_db.Character.Where(c => c.CampaignId == campId));
        }

        public Library.Character GetCharacterById(int id)
        {
            if (_db.Character.Any(c => c.CharacterId == id))
            {
                return Mapper.Map(_db.Character.First(c => c.CharacterId == id));
            }
            else { throw new ArgumentException("No existing characters with this ID."); }
        }

        public Library.CharStats GetCharStatsById(int id)
        {
            if (_db.CharStats.Any(c => c.CharacterId == id))
            {
                return Mapper.Map(_db.CharStats.First(c => c.CharacterId == id));
            }
            else { throw new ArgumentException("No stats exist for this character"); }
        }

        public Library.Race GetRaceById(int id)
        {
            return Mapper.Map(_db.Race.First(c => c.RaceId == id));
        }

        public Library.Class GetClassById(int id)
        {
            return Mapper.Map(_db.Class.First(c => c.ClassId == id));
        }

        public Library.Character GetCharacterByName(string name)
        {
            if (_db.Character.Any(c => c.Name.Equals(name)))
            {
                return Mapper.Map(_db.Character.First(c => c.Name.Equals(name)));
            }
            else { throw new ArgumentException("No existing characters with this name."); }
        }

        public IEnumerable<bool> GetSavingThrowProficiency(int classId)
        {
            if (_db.Class.Any(c => c.ClassId == classId))
            {
                // STR, DEX, CON, INT, WIS, CHA
                List<bool> proficiency = new List<bool> { false, false, false, false, false, false };

                switch (classId)
                {
                    case 1:
                        // Barbarian
                        proficiency[0] = true;
                        proficiency[2] = true;
                        break;
                    case 2:
                        // Fighter
                        proficiency[0] = true;
                        proficiency[2] = true;
                        break;
                    case 3:
                        // Paladin
                        proficiency[4] = true;
                        proficiency[5] = true;
                        break;
                    case 4:
                        // Bard
                        proficiency[1] = true;
                        proficiency[5] = true;
                        break;
                    case 5:
                        // Sorcerer
                        proficiency[2] = true;
                        proficiency[5] = true;
                        break;
                    case 6:
                        // Cleric
                        proficiency[4] = true;
                        proficiency[5] = true;
                        break;
                    case 7:
                        // Druid
                        proficiency[3] = true;
                        proficiency[4] = true;
                        break;
                    case 8:
                        // Ranger
                        proficiency[0] = true;
                        proficiency[1] = true;
                        break;
                    case 9:
                        // Rogue
                        proficiency[1] = true;
                        proficiency[3] = true;
                        break;
                    case 10:
                        // Wizard
                        proficiency[3] = true;
                        proficiency[4] = true;
                        break;
                }

                return proficiency;
            }
            else { throw new ArgumentException("No class with this ID exists."); }
        }

        public void SetSpeed(Library.Character character)
        {
            if (_db.Race.Any(r => r.RaceId == character.RaceID))
            { 
                if (character.RaceID == 1 || character.RaceID == 4 
                    || character.RaceID == 5) character.Speed = 20;
                else character.Speed = 30;
            }
            else { throw new ArgumentException("No race with this ID exists."); }
        }

        public void SetMaxHp(Library.Character character)
        {
            if (_db.Class.Any(c => c.ClassId == character.ClassID))
            {
                character.MaxHP = _db.Class.First(c => c.ClassId == character.ClassID).Hd;
            }
            else { throw new ArgumentException("No class with this ID exists."); }
        }

        public void SetSavingThrows(Library.Character character, Library.CharStats stats)
        {
            if (character != null && stats != null)
            {
                var proficiency = GetSavingThrowProficiency(character.ClassID).ToList();
                int pb = stats.PB;

                stats.STR_Save = CalculateSavingThrow(stats.STR_Mod, pb, proficiency[0]);
                stats.DEX_Save = CalculateSavingThrow(stats.DEX_Mod, pb, proficiency[1]);
                stats.CON_Save = CalculateSavingThrow(stats.CON_Mod, pb, proficiency[2]);
                stats.INT_Save = CalculateSavingThrow(stats.INT_Mod, pb, proficiency[3]);
                stats.WIS_Save = CalculateSavingThrow(stats.WIS_Mod, pb, proficiency[4]);
                stats.CHA_Save = CalculateSavingThrow(stats.CHA_Mod, pb, proficiency[5]);
            }
            else { throw new ArgumentNullException("Character cannot be null..."); }
        }

        public int CalculateSavingThrow(int val, int pb, bool proficient)
        {
            if (proficient)
            {
                return val + pb;
            }
            return val;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
