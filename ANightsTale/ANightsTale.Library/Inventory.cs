using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library
{
    public class Inventory
    {
        public int CharacterID { get; set; }
        public int ItemID { get; set; }       
        public int Quantity { get; set; }
        public bool? ToggleE { get; set; }
    }
}
