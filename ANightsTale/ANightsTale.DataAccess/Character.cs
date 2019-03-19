using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class Character
    {
        public Character()
        {
            CharAbilities = new HashSet<CharAbilities>();
            CharFeats = new HashSet<CharFeats>();
            CharStats = new HashSet<CharStats>();
            Inventory = new HashSet<Inventory>();
        }

        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int UsersId { get; set; }
        public int CampaignId { get; set; }
        public int RaceId { get; set; }
        public int ClassId { get; set; }
        public int? Experience { get; set; }
        public int? Level { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }
        public int Speed { get; set; }
        public int MaxHp { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Class Class { get; set; }
        public virtual Race Race { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<CharAbilities> CharAbilities { get; set; }
        public virtual ICollection<CharFeats> CharFeats { get; set; }
        public virtual ICollection<CharStats> CharStats { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
