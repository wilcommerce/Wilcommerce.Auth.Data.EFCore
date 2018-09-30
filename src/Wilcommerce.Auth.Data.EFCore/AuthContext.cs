using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wilcommerce.Auth.Models;

namespace Wilcommerce.Auth.Data.EFCore
{
    /// <summary>
    /// Defines the Entity Framework context for the auth package
    /// </summary>
    public class AuthContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Construct the auth context
        /// </summary>
        /// <param name="options">The context options</param>
        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {
            
        }

        /// <summary>
        /// Override the OnModelCreating method
        /// </summary>
        /// <param name="builder">The model builder instance</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity
                    .Relational()
                    .TableName = $"Wilcommerce_{entity.ClrType.Name}";
            }
        }
    }
}
