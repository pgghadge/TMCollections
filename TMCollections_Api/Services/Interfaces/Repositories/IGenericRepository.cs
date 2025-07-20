using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TMCollections_Api.Services.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class

    {
        Task<T?> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveChangesAsync();
    }
}
