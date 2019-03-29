using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    interface ISkillManager
    {
        void SetSkills(Library.CharStats stats);
        IEnumerable<Skill> GetSkillsByClass(int id);
        void UpdateSkills(List<int> skills, Library.CharStats stats);
    }
}
