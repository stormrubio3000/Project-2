using ANightsTale.DataAccess;
using ANightsTale.DataAccess.Repos;
using ANightsTale.Library;
using ANightsTale.Library.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Linq;
using Xunit;

namespace ANightsTale.Tests.Repos.Character
{
    public class CreateTests
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
                    var charRepo = new CharacterRepository(context, rand);
                    DataSeeding seed = new DataSeeding(context, charRepo);
                    seed.SeedCharacterSupportClasses();

                    var character = seed.SeedCharacter();

                    charRepo.AddCharacter(character);
                    charRepo.Save();

                    // Assert
                    Assert.Equal("Test", context.Character.First().Name);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void AddNullCharacterThrowsNullException()
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

                    // Assert
                    Assert.ThrowsAny<ArgumentNullException>(() => charRepo.AddCharacter(null));
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void AddCharStatsToDbIsSuccessful()
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
                    seed.SeedCharacterSupportClasses();

                    var character = seed.SeedCharacter();
                    var stats = seed.SeedCharStats(character);

                    charRepo.AddCharacter(character);
                    charRepo.Save();

                    charRepo.AddCharStats(stats);
                    charRepo.Save();

                    // Assert
                    Assert.Equal(1, context.CharStats.First().Id);
                    Assert.Equal(1, context.CharStats.First().CharacterId);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void AddNullCharStatsThrowsNullException()
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

                    // Assert
                    Assert.ThrowsAny<ArgumentNullException>(() => charRepo.AddCharStats(null));
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void AddRaceToDbIsSuccessful()
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
                    seed.SeedRace(1);
                    

                    // Assert
                    Assert.Equal(1, context.Race.First().RaceId);
                    Assert.Equal("TestRace", context.Race.First().Name);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void AddNullRaceThrowsNullException()
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

                    // Assert
                    Assert.ThrowsAny<ArgumentNullException>(() => charRepo.AddRace(null));
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void AddClassToDbIsSuccessful()
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
                    seed.SeedClass(1);


                    // Assert
                    Assert.Equal(1, context.Class.First().ClassId);
                    Assert.Equal("TestClass", context.Class.First().Name);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void AddNullClassThrowsNullException()
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

                    // Assert
                    Assert.ThrowsAny<ArgumentNullException>(() => charRepo.AddClass(null));
                }
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
