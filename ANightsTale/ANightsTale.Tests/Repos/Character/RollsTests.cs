﻿using ANightsTale.DataAccess;
using ANightsTale.DataAccess.Repos;
using ANightsTale.Library;
using ANightsTale.Library.CharacterLogic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ANightsTale.Tests.Repos.Character
{
    public class RollsTests
    {
        [Fact]
        public void RollsAreInTheRightRange()
        {
            var rand = new RngProvider();
            var roller = new RollManager(rand);

            var newRolls = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                newRolls = roller.DoRolls().ToList();
                Assert.Equal(3, newRolls.Count);
                for (int j = 0; j < 3; j++)
                {
                    Assert.True(newRolls[j] > 0 && newRolls[j] < 7);
                }
            }
        }

        [Fact]
        public void RollsSetProperly()
        {

            var rand = new RngProvider();
            var roller = new RollManager(rand);

            var character = new Library.Character();
            List<int> rolls = new List<int>() { 5, 18, 10, 11, 12, 14};

            roller.SetRolls(rolls, character);

            // Assert

            Assert.Equal(5, character.Str);
            Assert.Equal(18, character.Dex);
            Assert.Equal(10, character.Con);
            Assert.Equal(11, character.Int);
            Assert.Equal(12, character.Wis);
            Assert.Equal(14, character.Cha);
        }
    }
}
