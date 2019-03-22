using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface ICharacterRepository
    {
        void AddCharacter(Character character);
        void RemoveCharacter(Character character);
        void AddCharStats(CharStats stats);
        void RemoveCharStats(CharStats stats);
        void AddRace(Race race);
        void RemoveRace(Race race);
        void AddClass(Class myClass);
        void RemoveClass(Class myClass);

        IEnumerable<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        Character GetCharacterByName(string name);
        IEnumerable<bool> GetSavingThrowProficiency(int classId);

        void SetRace(int raceId);
        void SetClass(int classId);
        void SetRolls(IEnumerable<int> rolls);
        void SetModifiers();
        void SetSavingThrows();

        IEnumerable<int> InitialRolls();
        int CalculateModifier(int val);
        int CalculateSavingThrow(int val, int pb, bool proficient);
        void SetSkills();
        void UpdateSkills(List<int> skills, int charId);

        void Save();
    }
}
