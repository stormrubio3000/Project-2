using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class Item
    {
        public Item()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int? Ac { get; set; }
        public int? NumDice { get; set; }
        public int? NumSides { get; set; }
        public int? Mods { get; set; }
        public string Effects { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
