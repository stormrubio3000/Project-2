using System;
using System.Collections.Generic;
using System.Linq;
using ANightsTale.Library;
using ANightsTale.Library.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ANightsTale.DataAccess.Repos
{
	public class CharacterRepository : ICharacterRepository
    {

        private readonly ANightsTaleContext _db;
        private readonly RngProvider _rand;

        public CharacterRepository(ANightsTaleContext db, RngProvider rand)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _rand = rand ?? throw new ArgumentNullException(nameof(rand));
        }

        public void CreateCharacter(Library.Character character, IEnumerable<int> skills)
        {
            SetSpeed(character);
            SetMaxHp(character);

            var stats = new Library.CharStats();
            stats.CharacterID = character.CharacterID;
            stats.HP = character.MaxHP;

            SetModifiers(character, stats);
            SetSavingThrows(character, stats);
            SetSkills(stats);
            UpdateSkills(skills.ToList(), stats);

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
            if (stats != null) { _db.Add(Mapper.Map(stats)); }
            else { throw new ArgumentNullException(); }
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

        public IEnumerable<Library.Character> GetCharacterByCampUsr(int campId, int usrId)
        {

            if (_db.Character.Any(c => c.CampaignId == campId && c.UsersId == usrId))
            {
                return Mapper.Map(_db.Character.Where(c => c.CampaignId == campId && c.UsersId == usrId));
            }
            else { throw new ArgumentException("No existing characters with this ID."); }
        }

        public Library.Character GetCharacterById(int id)
        {
            if (_db.Character.Any(c => c.CharacterId == id))
            {
                return Mapper.Map(_db.Character.First(c => c.CharacterId == id));
            }
            else { throw new ArgumentException("No existing characters with this ID."); }
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

        public void SetRolls(IEnumerable<int> rolls, Library.Character character)
        {
            var attributes = rolls.ToList();

            character.Str = attributes[0];
            character.Dex = attributes[1];
            character.Con = attributes[2];
            character.Int = attributes[3];
            character.Wis = attributes[4];
            character.Cha = attributes[5];
        }

        public void SetModifiers(Library.Character character, Library.CharStats stats)
        {
            if (character == null || stats == null)
            {
                stats.STR_Mod = CalculateModifier(character.Str);
                stats.DEX_Mod = CalculateModifier(character.Dex);
                stats.CON_Mod = CalculateModifier(character.Con);
                stats.INT_Mod = CalculateModifier(character.Int);
                stats.WIS_Mod = CalculateModifier(character.Wis);
                stats.CHA_Mod = CalculateModifier(character.Cha);

                character.MaxHP += stats.CON_Mod;
            }
            else { throw new ArgumentNullException("Character cannot be null..."); }
        }

        public void SetSavingThrows(Library.Character character, Library.CharStats stats)
        {
            if (character == null || stats == null)
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

        public List<int> ManageRolls()
        {
            List<int> rolls = new List<int>();

            for (int j = 0; j < 4; j++)
            {
                rolls.Add(_rand.Rng.Next(1, 7));
            }

            return rolls.OrderBy(o => o).Skip(1).ToList();
        }

        public IEnumerable<int> InitialRolls()
        {
            List<int> rolls = new List<int>();
            List<int> totals = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                rolls = ManageRolls();

                totals.Add(rolls[0] + rolls[1] + rolls[2]);

                rolls.Clear();
            }

            return totals;
        }

        public int CalculateModifier(int val)
        {
            if (val >= 1 || val <= 20)
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
                else return 5;
            }
            else {
                throw new ArgumentOutOfRangeException("Attributes must be between 1 and 20 inclusive");
            }
        }

        public int CalculateSavingThrow(int val, int pb, bool proficient)
        {
            if (proficient)
            {
                return val + pb;
            }
            return val;
        }

        public void SetSkills(Library.CharStats stats)
        {
            //STR
            stats.Athletics = stats.STR_Mod;

            //DEX
            stats.Acrobatics = stats.DEX_Mod;
            stats.SleightOfHand = stats.DEX_Mod;
            stats.Stealth = stats.DEX_Mod;

            //INT
            stats.Arcana = stats.INT_Mod;
            stats.History = stats.INT_Mod;
            stats.Investigation = stats.INT_Mod;
            stats.Nature = stats.INT_Mod;
            stats.Religion = stats.INT_Mod;

            //WIS
            stats.AnimalHandling = stats.WIS_Mod;
            stats.Insight = stats.WIS_Mod;
            stats.Medicine = stats.WIS_Mod;
            stats.Perception = stats.WIS_Mod;
            stats.Survival = stats.WIS_Mod;

            //CHA
            stats.Deception = stats.CHA_Mod;
            stats.Intimidation = stats.CHA_Mod;
            stats.Persuasion = stats.CHA_Mod;
            stats.Performance = stats.CHA_Mod;
        }

        public void UpdateSkills(List<int> skills, Library.CharStats stats)
        {
            foreach (int skill in skills)
            {
                switch (skill)
                {
                    case 1:
                        // Acrobatics
                        stats.Acrobatics += stats.PB;
                        break;
                    case 2:
                        // AnimalHandling
                        stats.AnimalHandling += stats.PB;
                        break;
                    case 3:
                        // Arcana
                        stats.Arcana += stats.PB;
                        break;
                    case 4:
                        // Athletics
                        stats.Athletics += stats.PB;
                        break;
                    case 5:
                        // Deception
                        stats.Deception += stats.PB;
                        break;
                    case 6:
                        // History
                        stats.History += stats.PB;
                        break;
                    case 7:
                        // Insight
                        stats.Insight += stats.PB;
                        break;
                    case 8:
                        // Intimidation
                        stats.Intimidation += stats.PB;
                        break;
                    case 9:
                        // Investigation
                        stats.Investigation += stats.PB;
                        break;
                    case 10:
                        // Medicine
                        stats.Medicine += stats.PB;
                        break;
                    case 11:
                        // Nature
                        stats.Nature += stats.PB;
                        break;
                    case 12:
                        // Perception
                        stats.Perception += stats.PB;
                        break;
                    case 13:
                        // Performance
                        stats.Performance += stats.PB;
                        break;
                    case 14:
                        // Persuasion
                        stats.Persuasion += stats.PB;
                        break;
                    case 15:
                        // Religion
                        stats.Religion += stats.PB;
                        break;
                    case 16:
                        // Sleight Of Hand
                        stats.SleightOfHand += stats.PB;
                        break;
                    case 17:
                        // Stealth
                        stats.Stealth += stats.PB;
                        break;
                    case 18:
                        // Survival
                        stats.Survival += stats.PB;
                        break;
                    default:
                        throw new ArgumentException("This skill does not exist.");
                }
            }

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
