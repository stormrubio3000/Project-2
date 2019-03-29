using ANightsTale.DataAccess;
using ANightsTale.DataAccess.Repos;
using ANightsTale.Library;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ANightsTale.Tests.Repos.Character
{
    public class DeleteTests
    {
        [Fact]
        public void DeleteCharacterFromDbIsSuccessful()
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
                    var charRepo = new CharacterRepository(context);
                    DataSeeding seed = new DataSeeding(context, charRepo);

                    seed.SeedCharacterSupportClasses();
                    var character = seed.SeedCharacter();

                    charRepo.AddCharacter(character);
                    charRepo.Save();

                    charRepo.RemoveCharacter(1);
                    charRepo.Save();

                    // Assert
                    Assert.False(context.Character.Any());
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void DeleteCharacterFromDbAlsoDeletesCharStats()
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
                    var charRepo = new CharacterRepository(context);
                    DataSeeding seed = new DataSeeding(context, charRepo);
                    seed.SeedCharacterSupportClasses();

                    var character = seed.SeedCharacter();

                    charRepo.AddCharacter(character);
                    charRepo.Save();

                    var stats = seed.SeedCharStats(character);
                    charRepo.AddCharStats(stats);
                    charRepo.Save();

                    charRepo.RemoveCharacter(1);
                    charRepo.Save();

                    // Assert
                    Assert.False(context.CharStats.Any());
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
