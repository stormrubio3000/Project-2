using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class Class
    {
        public Class()
        {
            Character = new HashSet<Character>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Character> Character { get; set; }
    }
}
/*
 * 1.  Barbarian
 * 2.  Fighter
 * 3.  Paladin
 * 4.  Bard
 * 5.  Sorcerer
 * 6.  Cleric
 * 7.  Druid
 * 8.  Ranger
 * 9.  Rogue
 * 10. Wizard
 */
