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
    public class SavingThrowTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(5)]
        public void InvalidClassIdThrowsException(int id)
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
                    seed.SeedClass(3);

                    // Assert
                    Assert.ThrowsAny<ArgumentException>(() => charRepo.GetSavingThrowProficiency(id));
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void BarbarianProficiencyCalculatedCorrectly()
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

                    var val = charRepo.GetSavingThrowProficiency(1);

                    // Assert
                    Assert.Equal(new List<bool> { true, false, true, false, false ,false}, val);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void RogueProficiencyCalculatedCorrectly()
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
                    seed.SeedClass(9);

                    var val = charRepo.GetSavingThrowProficiency(9);

                    // Assert
                    Assert.Equal(new List<bool> { false, true, false, true, false, false }, val);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Integration test for GetSavingThrowPreficiency, SetSavingThrows, CalculateSavingThrows
        /// </summary>
        [Fact]
        public void SetAppropriateSavingThrows()
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

                    charRepo.SetSavingThrows();

                    var s = context.CharStats.First();

                    // Assert
                    Assert.Equal(-3, s.StrSave);
                    Assert.Equal(-1, s.DexSave);
                    Assert.Equal(3, s.ConSave);
                    Assert.Equal(2, s.IntSave);
                    Assert.Equal(0, s.WisSave);
                    Assert.Equal(-3, s.ChaSave);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void SetSavingThrowFailsWhenNoCharacterExists()
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
                    Assert.ThrowsAny<ArgumentNullException>((Action)charRepo.SetSavingThrows);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
