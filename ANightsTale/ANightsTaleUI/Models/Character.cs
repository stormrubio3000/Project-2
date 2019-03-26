using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleAPI.Models
{
    public class Character
    {
        public int CharacterID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string CampaignName { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }
        public int Speed { get; set; }
        public int MaxHP { get; set; }
    }
}
