using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface IAbilityRepository
    {
        void CreateAbility();
        void DeleteAbility();

        IEnumerable<Abilities> GetAllAbilities();
        Abilities GetAbilityById(int id);
        Abilities GetAbilityByName(string name);

        void SetNumberDice();
        void SetNumberSides();
        bool IsAttack();

        void Save();
    }
}
