using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface ICampaingRepository
    {
        void CreateCampaing(Campaign campaign);
        void DeleteCampaing(int id);

        IEnumerable<Campaign> GetAllCampaings();
        Campaign GetCampaingyId(int id);
        Campaign GetCampaingByName(string name);

        void CreateInfo(Info info);
        void DeleteInfo(int id);

        IEnumerable<Info> GetAllInfos();
        Info GetInfoId(int id);

        void Save();
    }
}
