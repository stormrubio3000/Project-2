using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class UserCampaign
    {
        public int UserId { get; set; }
        public int CampaignId { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Users User { get; set; }
    }
}
