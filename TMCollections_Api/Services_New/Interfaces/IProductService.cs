using TMCollections_Api.DTO.Product;

namespace TMCollections_Api.Services_New.Interfaces
{
    public interface IProductService
    {
        Task< List<ProductDto> > GetAllProductsAsync();
        Task< ProductDto? > GetByIdAsync(Guid id);
        Task CreateAsync(CreateProductDto dto);

        //Task UpdateAsync(Guid id, UpdateProductDto dto);
        Task DeleteAsync(Guid id);

        Task< (IEnumerable<ProductDto> products, int totalCount) > GetFilteredAsync(string? search, Guid? categoryId, int page, int pageSize);

    }
}
