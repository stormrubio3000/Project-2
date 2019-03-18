using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.DataAccess.Repos
{
    public interface ICharacterRepository
    {
        void CreateCharacter();
        void DeleteCharacter();

        IEnumerable<Library.Character> GetAllCharacters();
        Library.Character GetCharacterById(int id);
        Library.Character GetCharacterByName(string name);

        void RandomInitialRolls(int id);
        void InitialRolls(int id);
        void CalculateModifiers(int id);
        void CalculateSavingThrows(int id);
        void CalculateSkills(int id);

        void Save();
    }
}
