using Microsoft.EntityFrameworkCore;
using Wilcommerce.Auth.Models;

namespace Wilcommerce.Auth.Data.EFCore.Mapping
{
    /// <summary>
    /// Defines all the extension methods which maps the identity classes
    /// </summary>
    public static class IdentityMapping
    {
        /// <summary>
        /// Maps all the Identity classes
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
        public static ModelBuilder MapIdentity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.ProfileImage);

            return modelBuilder;
        }
    }
}
