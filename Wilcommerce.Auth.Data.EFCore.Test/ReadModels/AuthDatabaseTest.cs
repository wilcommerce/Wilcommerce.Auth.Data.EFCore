using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wilcommerce.Auth.Data.EFCore.ReadModels;
using Wilcommerce.Auth.Data.EFCore.Test.Fixtures;
using Wilcommerce.Auth.Models;
using Wilcommerce.Auth.Services;
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
        public void AuthDatabase_Should_Contain_A_PasswordRecovery_Token()
        {
            bool existsToken = _database.Tokens.Any(t => t.TokenType == TokenTypes.PasswordRecovery);
            Assert.True(existsToken);
        }

        [Fact]
        public void AuthDatabase_Should_Contain_A_Token_With_Fixture_Value()
        {
            bool existsToken = _database.Tokens.Any(t => t.Token == _fixture.Token);
            Assert.True(existsToken);
        }

        [Fact]
        public void AuthDatabase_Should_Contain_A_Token_With_TestAdmin_Id()
        {
            bool existsToken = _database.Tokens.Any(t => t.UserId == _fixture.TestAdmin.Id);
            Assert.True(existsToken);
        }
    }
}
