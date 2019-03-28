using ANightsTale.DataAccess;
using ANightsTale.DataAccess.Repos;
using ANightsTale.Library;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ANightsTale.Tests.Repos.Character
{
    public class RollsTests
    {
        [Fact]
        public void RollsAreInTheRightRange()
        {
            // arrange
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var rand = new RngProvider();
                var options = new DbContextOptionsBuilder<ANightsTaleContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new ANightsTaleContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Act

                // Run the test against one instance of the context
                using (var context = new ANightsTaleContext(options))
                {
                    var charRepo = new CharacterRepository(context, rand);
                    DataSeeding seed = new DataSeeding(context, charRepo);

                    var newRolls = new List<int>();
                    for (int i=0; i<100; i++)
                    {
                        newRolls = charRepo.ManageRolls();
                        Assert.Equal(3, newRolls.Count);
                        for (int j = 0; j < 3; j++)
                        {
                            Assert.True(newRolls[j] > 0 && newRolls[j] < 7);
                        }
                    }

                    // Assert
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void RollsSetProperly()
        {
            // arrange
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var rand = new RngProvider();
                var options = new DbContextOptionsBuilder<ANightsTaleContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new ANightsTaleContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Act

                // Run the test against one instance of the context
                using (var context = new ANightsTaleContext(options))
                {
                    var charRepo = new CharacterRepository(context, rand);
                    var character = new Library.Character();

                    List<int> rolls = new List<int>() { 5, 18, 10, 11, 12, 14};

                    charRepo.SetRolls(rolls, character);

                    // Assert

                    Assert.Equal(5, character.Str);
                    Assert.Equal(18, character.Dex);
                    Assert.Equal(10, character.Con);
                    Assert.Equal(11, character.Int);
                    Assert.Equal(12, character.Wis);
                    Assert.Equal(14, character.Cha);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
