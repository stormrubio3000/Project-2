using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(Users user);
        void DeleteUser(int id);

        IEnumerable<Users> GetAllUsers();
        Users GetUserById(int id);
        Users GetUserByUsername(string username);

        void CreateUserCampaign(UserCampaign userCampaign);
        void DeleteUserCampaign(int id);

        IEnumerable<UserCampaign> GetAllUsersCampaigns();

        void Save();
    }
}
