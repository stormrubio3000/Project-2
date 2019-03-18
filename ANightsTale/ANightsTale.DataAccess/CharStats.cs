using System;
using System.Collections.Generic;

namespace ANightsTale.DataAccess
{
    public partial class CharStats
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int Hp { get; set; }
        public int Ac { get; set; }
        public int Pb { get; set; }
        public int Gold { get; set; }
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
        public int StrSave { get; set; }
        public int DexSave { get; set; }
        public int ConSave { get; set; }
        public int IntSave { get; set; }
        public int WisSave { get; set; }
        public int ChaSave { get; set; }
        public int StrMod { get; set; }
        public int DexMod { get; set; }
        public int ConMod { get; set; }
        public int IntMod { get; set; }
        public int WisMod { get; set; }
        public int ChaMod { get; set; }

        public virtual Character Character { get; set; }
    }
}
