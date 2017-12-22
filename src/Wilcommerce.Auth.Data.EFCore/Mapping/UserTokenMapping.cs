using Microsoft.EntityFrameworkCore;
using Wilcommerce.Auth.Models;

namespace Wilcommerce.Auth.Data.EFCore.Mapping
{
    public static class UserTokenMapping
    {
        public static ModelBuilder MapUserToken(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserToken>()
                .ToTable("Wilcommerce_UserTokens");

            return modelBuilder;
        }
    }
}
