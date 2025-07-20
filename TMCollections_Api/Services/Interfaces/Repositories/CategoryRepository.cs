using Microsoft.EntityFrameworkCore;
using TMCollections_Api.Data;
using TMCollections_Api.Models;

namespace TMCollections_Api.Services.Interfaces.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetAllWithProductsAsync()
        {
            return await _dbSet.Include(x => x.Products).ToListAsync();
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
