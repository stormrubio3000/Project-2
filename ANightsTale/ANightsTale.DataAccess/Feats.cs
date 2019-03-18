using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class Feats
    {
        public Feats()
        {
            CharFeats = new HashSet<CharFeats>();
        }

        public int FeatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool StatTable { get; set; }
        public int StatType { get; set; }
        public int Mods { get; set; }

        public virtual ICollection<CharFeats> CharFeats { get; set; }
    }
}
