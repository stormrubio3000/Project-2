using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface ICampaignRepository
	{
        void CreateCampaign(Campaign campaign);
        void DeleteCampaign(int id);

        IEnumerable<Campaign> GetAllCampaigns();
        Campaign GetCampaignById(int id);
        Campaign GetCampaignByName(string name);

        void CreateInfo(Info info);
        void DeleteInfo(int id);

        IEnumerable<Info> GetAllInfos(int id);
        Info GetInfoId(int id);

        void Save();
    }
}
