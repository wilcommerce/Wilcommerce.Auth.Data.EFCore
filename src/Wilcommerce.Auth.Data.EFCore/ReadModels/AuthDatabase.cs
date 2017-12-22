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
        /// <param name="context"></param>
        public AuthDatabase(AuthContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get the tokens created by the platform
        /// </summary>
        public IQueryable<UserToken> Tokens => _context.UserTokens;
    }
}
