using System.Linq;
using Wilcommerce.Auth.Data.EFCore.ReadModels;
using Wilcommerce.Auth.Data.EFCore.Test.Fixtures;
using Wilcommerce.Auth.Models;
using Wilcommerce.Auth.ReadModels;
using Xunit;

namespace Wilcommerce.Auth.Data.EFCore.Test.ReadModels
{
    public class AuthDatabaseTest : IClassFixture<AuthContextFixture>
    {
        private AuthContextFixture _fixture;

        private AuthDatabase _database;

        public AuthDatabaseTest(AuthContextFixture fixture)
        {
            _fixture = fixture;
            _database = new AuthDatabase(fixture.Context);
        }

        [Fact]
        public void Users_Should_Contains_An_Administrator_User()
        {
            bool existAdministrator = _database.Users
                .Any(u => u.UserName == "admin@wilcommerce.com" && u.Email == "admin@wilcommerce.com" && u.Name == "Administrator");

            Assert.True(existAdministrator);
        }

        [Fact]
        public void Users_WithUsername_Should_Match_Given_Username()
        {
            bool exists = _database.Users
                .WithUsername("admin@wilcommerce.com")
                .Any();

            Assert.True(exists);
        }

        [Fact]
        public void Users_Actives_Should_Return_Only_Users_With_IsActive_Equal_To_True()
        {
            bool exists = _database.Users
                .Actives()
                .Any(u => !u.IsActive);

            Assert.False(exists);
        }
    }
}
