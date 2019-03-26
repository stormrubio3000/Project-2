using System.Collections.Generic;
using ANightsTale.Library;

namespace ANightsTale.DataAccess.Repos
{
	public interface IAbilityRepository
	{
		void CreateAbility(Library.Abilities ability);
		void CreateCharAbilities(Library.CharAbilities ability);
		void CreateCharFeat(Library.CharFeats feat);
		void CreateFeat(Library.Feats feat);
		void DeleteAbility(int id);
		void DeleteFeat(int id);
		Library.Abilities GetAbilityById(int id);
		Library.Abilities GetAbilityByName(string name);
		IEnumerable<Library.Abilities> GetAllAbilities();
		IEnumerable<Library.CharAbilities> GetAllCharAbilities();
		IEnumerable<Library.CharFeats> GetAllCharFeats();
		IEnumerable<Library.Feats> GetAllFeats();
		Library.CharAbilities GetCharAbilitiesById(int id);
		Library.CharFeats GetCharFeatById(int id);
		Library.Feats GetFeatById(int id);
		Library.Feats GetFeatByName(string name);
		void Save();
		void UpdateAbility(Library.Abilities ability);
		void UpdateFeat(Library.Feats feat);
	}
}