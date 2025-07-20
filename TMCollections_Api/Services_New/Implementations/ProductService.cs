using AutoMapper;
using TMCollections_Api.DTO.Product;
using TMCollections_Api.Models;

using TMCollections_Api.Services.Interfaces.Repositories;
using TMCollections_Api.Services_New.Interfaces;

namespace TMCollections_Api.Services_New.Implementations
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetProductsWithCategoryAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task CreateAsync(CreateProductDto dto)

        {
            //var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
            //if (category == null) throw new Exception("Invalid CategoryId");
            var product = _mapper.Map<Product>(dto);
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
        }

        //public async Task UpdateAsync(Guid id, UpdateProductDto dto)
        //{
        //    var existing = await _productRepository.GetByIdAsync(id);
        //    if (existing == null) throw new Exception("Product not found");
        //    _mapper.Map(dto, existing);
        //    _productRepository.Update(existing);
        //    await _productRepository.SaveChangesAsync();
        //}

        public async Task DeleteAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new Exception("Not found");
            _productRepository.Delete(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<(IEnumerable<ProductDto>, int)> GetFilteredAsync(string? search, Guid? categoryId, int page, int pageSize)
        {
            var products = await _productRepository.GetFilteredProductsAsync(search, categoryId, page, pageSize);
            var count = await _productRepository.GetTotalProductCountAsync(search, categoryId);
            return (_mapper.Map<IEnumerable<ProductDto>>(products), count);
        }
    }
}
