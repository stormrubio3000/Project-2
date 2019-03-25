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

        public void AddCharacter(Library.Character character)
        {
            if (character != null) { _db.Add(Mapper.Map(character)); }
            else { throw new ArgumentNullException(); }
        }

        public void RemoveCharacter(Library.Character character)
        {
            if (character != null) { _db.Remove(Mapper.Map(character)); }
            else { throw new ArgumentNullException(); }
        }

        public void AddCharStats(Library.CharStats stats)
        {
            if (stats != null) { _db.Add(Mapper.Map(stats)); }
            else { throw new ArgumentNullException(); }
        }

        public void RemoveCharStats(Library.CharStats stats)
        {
            if (stats != null) { _db.Remove(Mapper.Map(stats)); }
            else { throw new ArgumentNullException(); }
        }

        public void AddRace(Library.Race race)
        {
            if (race != null) { _db.Add(Mapper.Map(race)); }
            else { throw new ArgumentNullException(); }
        }

        public void RemoveRace(Library.Race race)
        {
            if (race != null) { _db.Remove(Mapper.Map(race)); }
            else { throw new ArgumentNullException(); }
        }

        public void AddClass(Library.Class myClass)
        {
            if (myClass != null) { _db.Add(Mapper.Map(myClass)); }
            else { throw new ArgumentNullException(); }
        }

        public void RemoveClass(Library.Class myClass)
        {
            if (myClass != null) { _db.Remove(Mapper.Map(myClass)); }
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

        public void SetRace(int raceId)
        {
            if (_db.Race.Any(r => r.RaceId == raceId))
            {
                var character = _db.Character.Last();
                character.RaceId = raceId;

                if (raceId == 1 || raceId == 4 || raceId == 5) character.Speed = 20;
                else character.Speed = 30;
            }
            else { throw new ArgumentException("No race with this ID exists."); }
        }

        public void SetClass(int classId)
        {
            if (_db.Class.Any(c => c.ClassId == classId))
            {
                _db.Character.Last().ClassId = classId;
                _db.Character.Last().MaxHp = _db.Class.First(c => c.ClassId == classId).Hd;
            }
            else { throw new ArgumentException("No class with this ID exists."); }
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
            if (_db.Character.Any() || _db.CharStats.Any())
            {
                var character = _db.Character.Last();
                var stats = _db.CharStats.First(s => s.CharacterId == character.CharacterId);

                stats.StrMod = CalculateModifier(character.Str);
                stats.DexMod = CalculateModifier(character.Dex);
                stats.ConMod = CalculateModifier(character.Con);
                stats.IntMod = CalculateModifier(character.Int);
                stats.WisMod = CalculateModifier(character.Wis);
                stats.ChaMod = CalculateModifier(character.Cha);

                character.MaxHp += stats.ConMod;
            }
            else { throw new ArgumentNullException("No characters in the DB."); }
        }

        public void SetSavingThrows()
        {
            if (_db.Character.Any() || _db.CharStats.Any())
            {
                var character = _db.Character.Last();
                var stats = _db.CharStats.First(s => s.CharacterId == character.CharacterId);
                var proficiency = GetSavingThrowProficiency(character.ClassId).ToList();
                int pb = stats.Pb;

                stats.StrSave = CalculateSavingThrow(stats.StrMod, pb, proficiency[0]);
                stats.DexSave = CalculateSavingThrow(stats.DexMod, pb, proficiency[1]);
                stats.ConSave = CalculateSavingThrow(stats.ConMod, pb, proficiency[2]);
                stats.IntSave = CalculateSavingThrow(stats.IntMod, pb, proficiency[3]);
                stats.WisSave = CalculateSavingThrow(stats.WisMod, pb, proficiency[4]);
                stats.ChaSave = CalculateSavingThrow(stats.ChaMod, pb, proficiency[5]);
            }
            else { throw new ArgumentNullException("No characters in the DB."); }
        }

        public IEnumerable<int> InitialRolls()
        {
            List<int> rolls = new List<int>();
            List<int> totals = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    rolls.Add(_rand.Rng.Next(1, 7));
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

        public void SetSkills()
        {
            var character = _db.Character.Last();
            var stats = _db.CharStats.First(s => s.CharacterId == character.CharacterId);

            //STR
            stats.Athletics = stats.StrMod;

            //DEX
            stats.Acrobatics = stats.DexMod;
            stats.SleightOfHand = stats.DexMod;
            stats.Stealth = stats.DexMod;

            //INT
            stats.Arcana = stats.IntMod;
            stats.History = stats.IntMod;
            stats.Investigation = stats.IntMod;
            stats.Nature = stats.IntMod;
            stats.Religion = stats.IntMod;

            //WIS
            stats.AnimalHandling = stats.WisMod;
            stats.Insight = stats.WisMod;
            stats.Medicine = stats.WisMod;
            stats.Perception = stats.WisMod;
            stats.Survival = stats.WisMod;

            //CHA
            stats.Deception = stats.ChaMod;
            stats.Intimidation = stats.ChaMod;
            stats.Persuasion = stats.ChaMod;
            stats.Performance = stats.ChaMod;
        }

        public void UpdateSkills(List<int> skills, int charId)
        {
            var stats = _db.CharStats.First(s => s.CharacterId == charId);

            foreach (int skill in skills)
            {
                switch (skill)
                {
                    case 1:
                        // Acrobatics
                        stats.Acrobatics += stats.Pb;
                        break;
                    case 2:
                        // AnimalHandling
                        stats.AnimalHandling += stats.Pb;
                        break;
                    case 3:
                        // Arcana
                        stats.Arcana += stats.Pb;
                        break;
                    case 4:
                        // Athletics
                        stats.Athletics += stats.Pb;
                        break;
                    case 5:
                        // Deception
                        stats.Deception += stats.Pb;
                        break;
                    case 6:
                        // History
                        stats.History += stats.Pb;
                        break;
                    case 7:
                        // Insight
                        stats.Insight += stats.Pb;
                        break;
                    case 8:
                        // Intimidation
                        stats.Intimidation += stats.Pb;
                        break;
                    case 9:
                        // Investigation
                        stats.Investigation += stats.Pb;
                        break;
                    case 10:
                        // Medicine
                        stats.Medicine += stats.Pb;
                        break;
                    case 11:
                        // Nature
                        stats.Nature += stats.Pb;
                        break;
                    case 12:
                        // Perception
                        stats.Perception += stats.Pb;
                        break;
                    case 13:
                        // Performance
                        stats.Performance += stats.Pb;
                        break;
                    case 14:
                        // Persuasion
                        stats.Persuasion += stats.Pb;
                        break;
                    case 15:
                        // Religion
                        stats.Religion += stats.Pb;
                        break;
                    case 16:
                        // Sleight Of Hand
                        stats.SleightOfHand += stats.Pb;
                        break;
                    case 17:
                        // Stealth
                        stats.Stealth += stats.Pb;
                        break;
                    case 18:
                        // Survival
                        stats.Survival += stats.Pb;
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
