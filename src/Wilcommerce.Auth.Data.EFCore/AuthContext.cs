using Microsoft.EntityFrameworkCore;
using Wilcommerce.Auth.Data.EFCore.Mapping;
using Wilcommerce.Auth.Models;

namespace Wilcommerce.Auth.Data.EFCore
{
    /// <summary>
    /// Defines the Entity Framework context for the auth package
    /// </summary>
    public class AuthContext : DbContext
    {
        /// <summary>
        /// Get or set the list of user tokens
        /// </summary>
        public virtual DbSet<UserToken> UserTokens { get; set; }

        /// <summary>
        /// Construct the auth context
        /// </summary>
        /// <param name="options">The context options</param>
        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// Override the <see cref="DbContext.OnModelCreating(ModelBuilder)"/>
        /// </summary>
        /// <param name="modelBuilder">The model builder instance</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .MapUserToken();

            base.OnModelCreating(modelBuilder);
        }
    }
}
