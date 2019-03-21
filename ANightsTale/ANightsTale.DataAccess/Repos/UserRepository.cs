using ANightsTale.Library;
using ANightsTale.Library.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANightsTale.DataAccess.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly ANightsTaleContext _db;

        public UserRepository(ANightsTaleContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void CreateUser(Library.Users user)
        {
            _db.Add(Mapper.Map(user));
        }

        public void CreateUserCampaign(Library.UserCampaign userCampaign)
        {
            _db.Add(Mapper.Map(userCampaign));
        }

        public void DeleteUser(int id)
        {
            _db.Remove(_db.Users.Find(id));
        }

        public void DeleteUserCampaign(int id)
        {
            _db.Remove(_db.UserCampaign.Find(id));
        }

        public IEnumerable<Library.Users> GetAllUsers()
        {
            return Mapper.Map(_db.Users);
        }

        public IEnumerable<Library.UserCampaign> GetAllUsersCampaigns()
        {
            return Mapper.Map(_db.UserCampaign);
        }

        public Library.Users GetUserById(int id)
        {
            return Mapper.Map(_db.Users.AsNoTracking().First(r => r.UsersId == id));
        }

        public Library.Users GetUserByUsername(string username)
        {
            return Mapper.Map(_db.Users.AsNoTracking().First(r => r.Username == username));
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
