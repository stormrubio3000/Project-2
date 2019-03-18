using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class Info
    {
        public int GameId { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public int CampaignId { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
