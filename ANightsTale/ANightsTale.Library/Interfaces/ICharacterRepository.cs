using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface ICharacterRepository
    {
        void AddCharacter(Character character);
        void RemoveCharacter(Character character);

        IEnumerable<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        Character GetCharacterByName(string name);

        void SetRace(int raceId);
        void SetClass(int classId);
        void SetRolls(IEnumerable<int> rolls);
        void SetModifiers();

        IEnumerable<int> InitialRolls();
        int CalculateModifier(int val);
        void CalculateSavingThrows(int id);
        void CalculateSkills(int id);

        void Save();
    }
}
