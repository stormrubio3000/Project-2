using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    interface IModifierManager
    {
        void SetModifiers(Library.Character character, Library.CharStats stats);
        int CalculateModifier(int val);
    }
}
