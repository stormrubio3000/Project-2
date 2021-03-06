﻿using ANightsTale.DataAccess;
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
                    var charRepo = new CharacterRepository(context);
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
                    var charRepo = new CharacterRepository(context);
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
                    var charRepo = new CharacterRepository(context);
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
                    var charRepo = new CharacterRepository(context);
                    DataSeeding seed = new DataSeeding(context, charRepo);
                    seed.SeedCharacterSupportClasses();

                    var character = seed.SeedCharacter();
                    var stats = seed.SeedCharStats(character);

                    charRepo.SetSavingThrows(character, stats);

                    // Assert
                    Assert.Equal(-3, stats.STR_Save);
                    Assert.Equal(-1, stats.DEX_Save);
                    Assert.Equal(3, stats.CON_Save);
                    Assert.Equal(2, stats.INT_Save);
                    Assert.Equal(0, stats.WIS_Save);
                    Assert.Equal(-3, stats.CHA_Save);
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
                    var charRepo = new CharacterRepository(context);

                    // Assert
                    Assert.ThrowsAny<ArgumentNullException>(() => charRepo.SetSavingThrows(null, null));
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
