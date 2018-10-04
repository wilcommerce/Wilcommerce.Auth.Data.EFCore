using System;
using System.Linq;
using Wilcommerce.Auth.Models;
using Wilcommerce.Auth.ReadModels;

namespace Wilcommerce.Auth.Data.EFCore.ReadModels
{
    /// <summary>
    /// Implementation of <see cref="IAuthDatabase"/>
    /// </summary>
    public class AuthDatabase : IAuthDatabase
    {
        /// <summary>
        /// The DbContext instance
        /// </summary>
        protected AuthContext _context;

        /// <summary>
        /// Construct the auth database
        /// </summary>
        /// <param name="context">The auth context instance</param>
        public AuthDatabase(AuthContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Get the list of users
        /// </summary>
        public IQueryable<User> Users => _context.Users;
    }
}
