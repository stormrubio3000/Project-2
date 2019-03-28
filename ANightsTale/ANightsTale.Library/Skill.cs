using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Skill(int id, string name)
        {
            Id = id;
            Name  =name;
        }
    }
}
