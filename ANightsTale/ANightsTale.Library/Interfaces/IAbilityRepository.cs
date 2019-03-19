using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface IAbilityRepository
    {
        void CreateAbility(Abilities ability);
        void DeleteAbility(int id);

        IEnumerable<Abilities> GetAllAbilities();
        Abilities GetAbilityById(int id);
        Abilities GetAbilityByName(string name);

        void CreateFeat(Feats feat);
        void DeleteFeat(int id);

        IEnumerable<Feats> GetAllFeats();
        Feats GetFeatById(int id);
        Feats GetFeatByName(string name);

        void UpdateAbility(Abilities ability);
        void UpdateFeat(Feats feat);

        void Save();
    }
}
