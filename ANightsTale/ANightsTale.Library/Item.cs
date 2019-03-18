using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int AC { get; set; }
        public int NumDice { get; set; }
        public int NumSides { get; set; }
        public int Mods { get; set; }
        public string Effects { get; set; }
    }
}
