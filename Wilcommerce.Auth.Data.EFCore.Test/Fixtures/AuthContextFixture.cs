using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using Wilcommerce.Auth.Models;

namespace Wilcommerce.Auth.Data.EFCore.Test.Fixtures
{
    public class AuthContextFixture : IDisposable
    {
        public AuthContext Context { get; protected set; }

        public IPasswordHasher<User> PasswordHasher { get; protected set; }

        public AuthContextFixture()
        {
            PasswordHasher = new Mock<IPasswordHasher<User>>().Object;

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
            if (Context.Users.Any())
            {
                Context.RemoveRange(Context.Users);
            }

            Context.SaveChanges();
        }

        protected virtual void PrepareData()
        {
            var user = User.CreateAsAdministrator("Administrator", "admin@wilcommerce.com", true);
            user.PasswordHash = PasswordHasher.HashPassword(user, "password");

            Context.Add(user);
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
