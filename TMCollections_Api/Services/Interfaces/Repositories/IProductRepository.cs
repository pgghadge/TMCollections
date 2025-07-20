using TMCollections_Api.Models;

namespace TMCollections_Api.Services.Interfaces.Repositories
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId);
        Task<IEnumerable<Product>> GetProductsByCollectionAsync(Guid collectionId);
        Task<IEnumerable<Product>> GetProductsByBrandAsync(Guid brandId);
        Task<IEnumerable<Product>> GetProductsBySearchTermAsync(string searchTerm);
        Task<IEnumerable<Product>> GetFeaturedProductsAsync();
        Task<IEnumerable<Product>> GetNewArrivalsAsync();
        Task<IEnumerable<Product>> GetTopRatedProductsAsync();
        Task<List<Product>> GetProductsWithCategoryAsync();


        Task<IEnumerable<Product>> GetFilteredProductsAsync(string? search, Guid? categoryId, int page, int pageSize);
        Task<int> GetTotalProductCountAsync(string? search, Guid? categoryId);


    }
}
