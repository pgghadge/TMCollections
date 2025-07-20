using System.Globalization;
using TMCollections_Api.Models;

namespace TMCollections_Api.Services.Interfaces.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetAllWithProductsAsync();

        Task<Category?> GetByNameAsync(string name);
    }
}
