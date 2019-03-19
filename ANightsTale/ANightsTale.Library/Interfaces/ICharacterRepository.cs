using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface ICharacterRepository
    {
        void AddCharacter(Character character);
        void RemoveCharacter(Character character);

        void CreateCharacter(string name, string bio = null);

        IEnumerable<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        Character GetCharacterByName(string name);

        void SetRace(Race r);
        void SetClass(Class c);
        void SetRolls(IEnumerable<int> rolls);

        IEnumerable<int> InitialRolls();
        void CalculateModifiers(int id);
        void CalculateSavingThrows(int id);
        void CalculateSkills(int id);

        void Save();
    }
}
