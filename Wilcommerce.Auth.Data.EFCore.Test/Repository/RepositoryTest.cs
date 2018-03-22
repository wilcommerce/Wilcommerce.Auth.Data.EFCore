using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Linq;
using Wilcommerce.Auth.Data.EFCore.ReadModels;
using Wilcommerce.Auth.Data.EFCore.Test.Fixtures;
using Wilcommerce.Auth.Models;
using Wilcommerce.Auth.Services;
using Wilcommerce.Core.Common.Domain.Models;
using Xunit;

namespace Wilcommerce.Auth.Data.EFCore.Test.Repository
{
    public class RepositoryTest : IClassFixture<AuthContextFixture>
    {
        private AuthContextFixture _fixture;

        private AuthDatabase _database;

        private EFCore.Repository.Repository _repository;

        public RepositoryTest(AuthContextFixture fixture)
        {
            _fixture = fixture;
            _database = new AuthDatabase(fixture.Context);
            _repository = new EFCore.Repository.Repository(fixture.Context);
        }

        [Fact]
        public void AddToken_Should_Increment_Tokens_Number()
        {
            var tokensCount = _database.Tokens.Count();

            var passwordHasher = new Mock<IPasswordHasher<User>>().Object;
            var admin = User.CreateAsAdministrator("Admin2", "admin2@admin.com", "password", passwordHasher);
            var tokenGenerator = new TokenGenerator();
            string token = tokenGenerator.GenerateForUser(admin);

            var userToken = UserToken.Registration(admin, token, DateTime.Now.AddDays(1));
            _repository.Add(userToken);
            _repository.SaveChanges();

            Assert.Equal(tokensCount + 1, _database.Tokens.Count());
        }
    }
}
