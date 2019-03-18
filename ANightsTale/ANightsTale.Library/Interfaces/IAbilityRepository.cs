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

        void CreateFeat();
        void DeleteFeat();

        IEnumerable<Feats> GetAllFeat();
        Feats GetFeatById(int id);
        Feats GetFeatByName(string name);

        void SetNumberDice();
        void SetNumberSides();
        bool IsAttack();

        void Save();
    }
}
