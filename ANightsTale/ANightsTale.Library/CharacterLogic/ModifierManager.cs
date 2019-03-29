using ANightsTale.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.CharacterLogic
{
    public class ModifierManager : IModifierManager
    {
        public void SetModifiers(Library.Character character, Library.CharStats stats)
        {
            if (character == null || stats == null)
            {
                stats.STR_Mod = CalculateModifier(character.Str);
                stats.DEX_Mod = CalculateModifier(character.Dex);
                stats.CON_Mod = CalculateModifier(character.Con);
                stats.INT_Mod = CalculateModifier(character.Int);
                stats.WIS_Mod = CalculateModifier(character.Wis);
                stats.CHA_Mod = CalculateModifier(character.Cha);

                character.MaxHP += stats.CON_Mod;
            }
            else { throw new ArgumentNullException("Character cannot be null..."); }
        }

        public int CalculateModifier(int val)
        {
            if (val >= 1 || val <= 20)
            {
                if (val == 1) return -5;
                else if (val == 2 || val == 3) return -4;
                else if (val == 4 || val == 5) return -3;
                else if (val == 6 || val == 7) return -2;
                else if (val == 8 || val == 9) return -1;
                else if (val == 10 || val == 11) return 0;
                else if (val == 12 || val == 13) return 1;
                else if (val == 14 || val == 15) return 2;
                else if (val == 16 || val == 17) return 3;
                else if (val == 18 || val == 19) return 4;
                else return 5;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Attributes must be between 1 and 20 inclusive");
            }
        }
    }
}
