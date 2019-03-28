using ANightsTale.Library;
using ANightsTale.Library.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANightsTale.DataAccess.Repos
{
    public class AbilityRepository : IAbilityRepository
	{
        private readonly ANightsTaleContext _db;

        public AbilityRepository(ANightsTaleContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void CreateAbility(Library.Abilities ability)
        {
            _db.Add(Mapper.Map(ability));
        }

        public void CreateFeat(Library.Feats feat)
        {
            _db.Add(Mapper.Map(feat));
        }

        public void DeleteAbility(int id)
        {
            _db.Remove(_db.Abilities.Find(id));
        }

        public void DeleteFeat(int id)
        {
            _db.Remove(_db.Feats.Find(id));
        }

        public Library.Abilities GetAbilityById(int id)
        {
            return Mapper.Map(_db.Abilities.AsNoTracking().First(r => r.AbilityId == id));
        }

        public Library.Abilities GetAbilityByName(string name)
        {
            return Mapper.Map(_db.Abilities.AsNoTracking().First(r => r.Name == name));
        }

        public IEnumerable<Library.Abilities> GetAllAbilities()
        {
            return Mapper.Map(_db.Abilities);
        }

        public Library.Feats GetFeatById(int id)
        {
            return Mapper.Map(_db.Feats.AsNoTracking().First(r => r.FeatId == id));
        }

        public Library.Feats GetFeatByName(string name)
        {
            return Mapper.Map(_db.Feats.AsNoTracking().First(r => r.Name == name));
        }

        public IEnumerable<Library.Feats> GetAllFeats()
        {
            return Mapper.Map(_db.Feats);
        }
 
        public void UpdateAbility(Library.Abilities ability)
        {
            _db.Entry(_db.Abilities.Find(ability.AbilityID)).CurrentValues.SetValues(Mapper.Map(ability));
        }

        public void UpdateFeat(Library.Feats feat)
        {
            _db.Entry(_db.Feats.Find(feat.FeatID)).CurrentValues.SetValues(Mapper.Map(feat));
        }

		public IEnumerable<Library.CharFeats> GetAllCharFeats()
		{
			return Mapper.Map(_db.CharFeats);
		}

		public Library.CharFeats GetCharFeatById(int id)
		{
			return Mapper.Map(_db.CharFeats.AsNoTracking().First(r => r.FeatId == id));
		}

		public void CreateCharFeat(Library.CharFeats feat)
		{
			_db.Add(Mapper.Map(feat));
		}

		public IEnumerable<Library.CharAbilities> GetAllCharAbilities()
		{
			return Mapper.Map(_db.CharAbilities);
		}

		public Library.CharAbilities GetCharAbilitiesById(int id)
		{
			return Mapper.Map(_db.CharAbilities.AsNoTracking().First(r => r.AbilityId == id));
		}

		public void CreateCharAbilities(Library.CharAbilities ability)
		{
			_db.Add(Mapper.Map(ability));
		}

		public void Save()
        {
            _db.SaveChanges();
        }
    }
}
