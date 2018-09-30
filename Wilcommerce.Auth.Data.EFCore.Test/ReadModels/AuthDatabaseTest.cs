using System.Linq;
using Wilcommerce.Auth.Data.EFCore.ReadModels;
using Wilcommerce.Auth.Data.EFCore.Test.Fixtures;
using Wilcommerce.Auth.Models;
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

        
    }
}
