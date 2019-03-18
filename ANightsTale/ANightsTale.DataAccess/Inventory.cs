using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class Inventory
    {
        public int CharacterId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public bool? ToggleE { get; set; }

        public virtual Character Character { get; set; }
        public virtual Item Item { get; set; }
    }
}
