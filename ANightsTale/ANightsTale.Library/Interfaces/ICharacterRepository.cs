using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface ICharacterRepository
    {
        void CreateCharacter();
        void DeleteCharacter();

        IEnumerable<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        Character GetCharacterByName(string name);

        void RandomInitialRolls(int id);
        void InitialRolls(int id);
        void CalculateModifiers(int id);
        void CalculateSavingThrows(int id);
        void CalculateSkills(int id);

        void Save();
    }
}
