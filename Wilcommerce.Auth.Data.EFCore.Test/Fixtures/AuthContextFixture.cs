using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Wilcommerce.Auth.Models;
using Wilcommerce.Auth.Services;

namespace Wilcommerce.Auth.Data.EFCore.Test.Fixtures
{
    public class AuthContextFixture : IDisposable
    {
        public AuthContext Context { get; protected set; }

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
            
        }

        protected virtual void PrepareData()
        {
            
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
