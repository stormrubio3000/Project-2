using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class Abilities
    {
        public Abilities()
        {
            CharAbilities = new HashSet<CharAbilities>();
        }

        public int AbilityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RequiredLv { get; set; }
        public int RequiredClass { get; set; }
        public int? NumDice { get; set; }
        public int? NumSides { get; set; }
        public bool? Attack { get; set; }

        public virtual ICollection<CharAbilities> CharAbilities { get; set; }
    }
}
