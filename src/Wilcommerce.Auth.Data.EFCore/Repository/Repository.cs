using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wilcommerce.Core.Infrastructure;

namespace Wilcommerce.Auth.Data.EFCore.Repository
{
    /// <summary>
    /// Implementation of <see cref="Auth.Repository.IRepository"/>
    /// </summary>
    public class Repository : Auth.Repository.IRepository
    {
        /// <summary>
        /// The DbContext instance
        /// </summary>
        protected AuthContext _context;

        /// <summary>
        /// Construct the repository
        /// </summary>
        /// <param name="context">The auth context instance</param>
        public Repository(AuthContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dispose all the resource used
        /// </summary>
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Saves all the changes made on the aggregate
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Async method. Saves all the changes made on the aggregate
        /// </summary>
        /// <returns></returns>
        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Add an aggregate to the repository
        /// </summary>
        /// <typeparam name="TModel">The aggregate's type</typeparam>
        /// <param name="model">The aggregate to add</param>
        public void Add<TModel>(TModel model) where TModel : class, IAggregateRoot
        {
            try
            {
                _context.Set<TModel>().Add(model);
            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the aggregate based on the specified key
        /// </summary>
        /// <typeparam name="TModel">The aggregate's type</typeparam>
        /// <param name="key">The key of the aggregate to search</param>
        /// <returns>The aggregate found</returns>
        public TModel GetByKey<TModel>(Guid key) where TModel : class, IAggregateRoot
        {
            try
            {
                return _context.Find<TModel>(key);
            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Async method. Gets the aggregate based on the specified key
        /// </summary>
        /// <typeparam name="TModel">The aggregate's type</typeparam>
        /// <param name="key">The key of the aggregate to search</param>
        /// <returns>The aggregate found</returns>
        public async Task<TModel> GetByKeyAsync<TModel>(Guid key) where TModel : class, IAggregateRoot
        {
            try
            {
                var model = await _context.FindAsync<TModel>(key);
                return model;
            }
            catch 
            {
                throw;
            }
        }
    }
}
