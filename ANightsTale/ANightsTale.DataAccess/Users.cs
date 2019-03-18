using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class Users
    {
        public Users()
        {
            UserCampaign = new HashSet<UserCampaign>();
        }

        public int UsersId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Permission { get; set; }
        public string Email { get; set; }

        public virtual ICollection<UserCampaign> UserCampaign { get; set; }
    }
}
