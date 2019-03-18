using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class Race
    {
        public Race()
        {
            Character = new HashSet<Character>();
        }

        public int RaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Character> Character { get; set; }
    }
}

/*
 * 1. Dwarf
 * 2. Human
 * 3. Elf
 * 4. Halfling
 * 5. Gnomes
 * 6. Half-Orc
 */
