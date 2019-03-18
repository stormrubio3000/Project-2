using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class CharAbilities
    {
        public int CharacterId { get; set; }
        public int AbilityId { get; set; }
        public int? Mods { get; set; }

        public virtual Abilities Ability { get; set; }
        public virtual Character Character { get; set; }
    }
}
