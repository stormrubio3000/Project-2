using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    interface IRollManager
    {
        IEnumerable<int> DoRolls();
        IEnumerable<int> InitialRolls();
        void SetRolls(IEnumerable<int> rolls, Library.Character character);
    }
}
