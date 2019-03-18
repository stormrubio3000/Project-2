using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class CharFeats
    {
        public int CharacterId { get; set; }
        public int FeatId { get; set; }

        public virtual Character Character { get; set; }
        public virtual Feats Feat { get; set; }
    }
}
