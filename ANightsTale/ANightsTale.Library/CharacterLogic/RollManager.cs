using ANightsTale.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANightsTale.Library.CharacterLogic
{
    public class RollManager : IRollManager
    {
        private readonly RngProvider _rand;

        public RollManager(RngProvider rand)
        {
            _rand = rand;
        }

        public IEnumerable<int> DoRolls()
        {
            List<int> rolls = new List<int>();

            for (int j = 0; j < 4; j++)
            {
                rolls.Add(_rand.Rng.Next(1, 7));
            }

            return rolls.OrderBy(o => o).Skip(1).ToList();
        }

        public IEnumerable<int> InitialRolls()
        {
            List<int> rolls = new List<int>();
            List<int> totals = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                rolls = DoRolls().ToList();

                totals.Add(rolls[0] + rolls[1] + rolls[2]);

                rolls.Clear();
            }

            return totals;
        }

        public void SetRolls(IEnumerable<int> rolls, Library.Character character)
        {
            var attributes = rolls.ToList();

            character.Str = attributes[0];
            character.Dex = attributes[1];
            character.Con = attributes[2];
            character.Int = attributes[3];
            character.Wis = attributes[4];
            character.Cha = attributes[5];
        }
    }
}
