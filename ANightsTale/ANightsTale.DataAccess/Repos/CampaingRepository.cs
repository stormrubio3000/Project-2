using ANightsTale.Library;
using ANightsTale.Library.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANightsTale.DataAccess.Repos
{
    public class CampaingRepository : ICampaingRepository
    {
        private readonly ANightsTaleContext _db;

        public CampaingRepository(ANightsTaleContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void CreateCampaing(Library.Campaign campaign)
        {
            _db.Add(Mapper.Map(campaign));
        }

        public void CreateInfo(Library.Info info)
        {
            _db.Add(Mapper.Map(info));
        }

        public void DeleteCampaing(int id)
        {
            _db.Remove(_db.Campaign.Find(id));
        }

        public void DeleteInfo(int id)
        {
            _db.Remove(_db.Info.Find(id));
        }

        public IEnumerable<Library.Campaign> GetAllCampaings()
        {
            return Mapper.Map(_db.Campaign);
        }

        public IEnumerable<Library.Info> GetAllInfos()
        {
            return Mapper.Map(_db.Info);
        }

        public Library.Campaign GetCampaingByName(string name)
        {
            return Mapper.Map(_db.Campaign.AsNoTracking().First(r => r.Name == name));
        }

        public Library.Campaign GetCampaingyId(int id)
        {
            return Mapper.Map(_db.Campaign.AsNoTracking().First(r => r.CampaignId == id));
        }

        public Library.Info GetInfoId(int id)
        {
            return Mapper.Map(_db.Info.AsNoTracking().First(r => r.InfoId == id));
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
