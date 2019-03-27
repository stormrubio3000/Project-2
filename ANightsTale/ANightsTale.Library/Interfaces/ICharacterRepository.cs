using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface ICharacterRepository
    {
        void CreateCharacter(Character character, IEnumerable<int> skills);

        void AddCharacter(Character character);
        void RemoveCharacter(int id);
        void AddCharStats(CharStats stats);
        void RemoveCharStats(int id);
        void AddRace(Race race);
        void RemoveRace(int id);
        void AddClass(Class myClass);
        void RemoveClass(int id);

        IEnumerable<Character> GetAllCharacters();
        IEnumerable<Race> GetAllRaces();
        IEnumerable<Class> GetAllClasses();
        Character GetCharacterById(int id);
        Character GetCharacterByName(string name);
        IEnumerable<bool> GetSavingThrowProficiency(int classId);

        void SetSpeed(Character character);
        void SetMaxHp(Character character);
        void SetRolls(IEnumerable<int> rolls, Library.Character character);
        void SetModifiers(Character character, CharStats stats);
        void SetSavingThrows(Character character, CharStats stats);
        void SetSkills(CharStats stats);

        IEnumerable<int> InitialRolls();
        List<int> ManageRolls();
        int CalculateModifier(int val);
        int CalculateSavingThrow(int val, int pb, bool proficient);
        void UpdateSkills(List<int> skills, CharStats stats);

        void Save();
    }
}
