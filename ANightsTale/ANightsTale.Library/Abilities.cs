using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library
{
    public class Abilities
    {
        public int AbilityID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? NumDice { get; set; }
        public int? NumSides { get; set; }
        public bool? Attack { get; set; }
    }
}
