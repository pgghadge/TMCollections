using Microsoft.EntityFrameworkCore;
using TMCollections_Api.Data;
using TMCollections_Api.Models;

namespace TMCollections_Api.Services.Interfaces.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Product>> GetFeaturedProductsAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<Product>> GetFilteredProductsAsync(string? search, Guid? categoryId, int page, int pageSize)
        {
            var query = _dbSet.Include(p => p.Category).AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Name.Contains(search) || p.Description.Contains(search));

            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            return await query.ToListAsync();
        }



        public Task<IEnumerable<Product>> GetNewArrivalsAsync()
        {

            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByBrandAsync(Guid brandId)
        {
            throw new NotImplementedException();
        }

        public async Task< IEnumerable<Product> > GetProductsByCategoryAsync(Guid categoryId)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

        }

        public Task<IEnumerable<Product>> GetProductsByCollectionAsync(Guid collectionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsBySearchTermAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public  async Task< List<Product> > GetProductsWithCategoryAsync()
        {
            return await _dbSet
                .Include(p => p.Category)
                .ToListAsync();
        }

        public Task<IEnumerable<Product>> GetTopRatedProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalProductCountAsync(string? search, Guid? categoryId)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Name.Contains(search) || p.Description.Contains(search));

            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            return await query.CountAsync();
        }
    }
}
