using Microsoft.EntityFrameworkCore;
using Wilcommerce.Auth.Data.EFCore.Mapping;
using Wilcommerce.Auth.Models;

namespace Wilcommerce.Auth.Data.EFCore
{
    public class AuthContext : DbContext
    {
        public virtual DbSet<UserToken> UserTokens { get; set; }

        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .MapUserToken();

            base.OnModelCreating(modelBuilder);
        }
    }
}
