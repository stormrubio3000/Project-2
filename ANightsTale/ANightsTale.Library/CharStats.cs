using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library
{
    public class CharStats
    {
        public int ID { get; set; }
        public int CharacterID { get; set; }
        public int HP { get; set; }
        public int AC { get; set; }
        public int PB { get; set; }
        public int Gold { get; set; }

        // Skills
        public int Acrobatics { get; set; }
        public int AnimalHandling { get; set; }
        public int Arcana { get; set; }
        public int Athletics { get; set; }
        public int Deception { get; set; }
        public int History { get; set; }
        public int Insight { get; set; }
        public int Intimidation { get; set; }
        public int Investigation { get; set; }
        public int Medicine { get; set; }
        public int Nature { get; set; }
        public int Perception { get; set; }
        public int Performance { get; set; }
        public int Persuasion { get; set; }
        public int Religion { get; set; }
        public int SleightOfHand { get; set; }
        public int Stealth { get; set; }
        public int Survival { get; set; }

        // Saving Throws
        public int STR_Save { get; set; }
        public int DEX_Save { get; set; }
        public int CON_Save { get; set; }
        public int INT_Save { get; set; }
        public int WIS_Save { get; set; }
        public int CHA_Save { get; set; }

        // Stat Modifiers
        public int STR_Mod { get; set; }
        public int DEX_Mod { get; set; }
        public int CON_Mod { get; set; }
        public int INT_Mod { get; set; }
        public int WIS_Mod { get; set; }
        public int CHA_Mod { get; set; }
    }
}
