using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class Campaign
    {
        public Campaign()
        {
            Character = new HashSet<Character>();
            Info = new HashSet<Info>();
            UserCampaign = new HashSet<UserCampaign>();
        }

        public int CampaignId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Character> Character { get; set; }
        public virtual ICollection<Info> Info { get; set; }
        public virtual ICollection<UserCampaign> UserCampaign { get; set; }
    }
}
