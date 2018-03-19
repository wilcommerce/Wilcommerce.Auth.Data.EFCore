using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Wilcommerce.Auth.Models;
using Wilcommerce.Auth.Services;
using Wilcommerce.Core.Common.Domain.Models;

namespace Wilcommerce.Auth.Data.EFCore.Test.Fixtures
{
    public class AuthContextFixture : IDisposable
    {
        public AuthContext Context { get; protected set; }

        public User TestAdmin { get; protected set; }

        public string Token { get; protected set; }

        public AuthContextFixture()
        {
            BuildContext();
            PrepareData();
        }

        public void Dispose()
        {
            CleanData();
            if (Context != null)
            {
                Context.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        protected virtual void CleanData()
        {
            Context.UserTokens.RemoveRange(Context.UserTokens);
        }

        protected virtual void PrepareData()
        {
            var passwordHasher = new Mock<IPasswordHasher<User>>().Object;

            TestAdmin = User.CreateAsAdministrator("Admin", "admin@admin.com", "password", passwordHasher);
            var tokenGenerator = new TokenGenerator();
            Token = tokenGenerator.GenerateForUser(TestAdmin);

            var userToken = UserToken.PasswordRecovery(TestAdmin, Token, DateTime.Now.AddDays(10));

            Context.UserTokens.Add(userToken);
            Context.SaveChanges();
        }

        protected virtual void BuildContext()
        {
            var options = new DbContextOptionsBuilder<AuthContext>()
                .UseInMemoryDatabase(databaseName: "InMemory-Auth")
                .Options;

            Context = new AuthContext(options);
        }
    }
}
