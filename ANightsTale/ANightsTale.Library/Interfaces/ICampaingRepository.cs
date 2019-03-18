using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface ICampaingRepository
    {
        void CreateCampaing();
        void DeleteCampaing();
        IEnumerable<Character> GetAllCampaings();
        Character GetCampaingyId(int id);
        Character GetCampaingByName(string name);
    }
}
