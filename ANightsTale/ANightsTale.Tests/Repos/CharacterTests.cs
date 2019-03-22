using ANightsTale.DataAccess;
using ANightsTale.DataAccess.Repos;
using ANightsTale.Library;
using ANightsTale.Library.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using Xunit;

namespace ANightsTale.Tests
{
    public class CharacterTests
    {
        [Fact]        
        public void AddCharacterToDbIsSuccessful()
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
                    var repo = new CharacterRepository(context, rand);
                    var character = new Library.Character
                    {
                        UserId = 1,
                        Name = "Test",
                        Bio = "Stuff",
                        CampaignID = 1,
                        RaceID = 1,
                        ClassID = 1,
                        Experience = 0,
                        Level = 1,
                        Str = 1, Dex = 1, Con = 1, Int = 1, Wis = 1, Cha = 1,
                        Speed = 1, MaxHP = 1
                    };

                    repo.AddCharacter(character);
                    repo.Save();

                    // Assert
                    Assert.Equal(1, repo.GetCharacterById(1).CharacterID);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
