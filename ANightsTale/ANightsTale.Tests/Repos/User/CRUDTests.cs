using ANightsTale.DataAccess;
using ANightsTale.DataAccess.Repos;
using ANightsTale.Library;
using ANightsTale.Library.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using Xunit;

namespace ANightsTale.Tests.Repos.User
{
    public class CRUDTests
    {
        [Fact]
        public void AddUserToDbIsSuccessful()
        {
            // arrange
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
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
                    var repo = new UserRepository(context);

                    Library.Users user = new Library.Users
                    {
                        Username = "Test",
                        Password = "Test",
                        Permission = 0,
                        Email = "test@test.com"
                    };

                    repo.CreateUser(user);
                    repo.Save();

                    // Assert
                    Assert.Equal(1, repo.GetUserById(1).UserID);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void DeleteUserFromDbIsSuccessful()
        {
            // arrange
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
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
                    var repo = new UserRepository(context);

                    Library.Users user = new Library.Users
                    {
                        Username = "Test",
                        Password = "Test",
                        Permission = 0,
                        Email = "test@test.com"
                    };

                    repo.CreateUser(user);
                    repo.Save();

                    repo.DeleteUser(1);
                    repo.Save();

                    // Assert
                    Assert.Empty(context.Users);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
