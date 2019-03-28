using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library
{
    public class Campaign
    {
        public int CampaignID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Info> Infos { get; set; }
    }
}
