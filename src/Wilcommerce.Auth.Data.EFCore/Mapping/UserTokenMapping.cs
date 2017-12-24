using Microsoft.EntityFrameworkCore;
using Wilcommerce.Auth.Models;

namespace Wilcommerce.Auth.Data.EFCore.Mapping
{
    /// <summary>
    /// Defines the modelBuilder's extension methods to map the <see cref="UserToken"/> class
    /// </summary>
    public static class UserTokenMapping
    {
        /// <summary>
        /// Extension method. Maps the user token class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
        public static ModelBuilder MapUserToken(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserToken>()
                .ToTable("Wilcommerce_UserTokens");

            return modelBuilder;
        }
    }
}
