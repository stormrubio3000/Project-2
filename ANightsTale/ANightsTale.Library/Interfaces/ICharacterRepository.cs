using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface ICharacterRepository
    {
        void AddCharacter(Character character);
        void RemoveCharacter(Character character);

        //void CreateCharacter(string name, IEnumerable<int> rolls,
        //                     int raceId, int classId, string bio = null);

        IEnumerable<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        Character GetCharacterByName(string name);

        void SetRace(int raceId);
        void SetClass(int classId);
        void SetRolls(IEnumerable<int> rolls);
        void SetInitialHp();

        IEnumerable<int> InitialRolls();
        void CalculateModifiers(int id);
        void CalculateSavingThrows(int id);
        void CalculateSkills(int id);

        void Save();
    }
}
