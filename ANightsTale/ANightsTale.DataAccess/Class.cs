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
