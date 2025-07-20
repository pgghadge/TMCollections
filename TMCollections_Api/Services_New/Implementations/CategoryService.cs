using AutoMapper;
using TMCollections_Api.DTO.Category;
using TMCollections_Api.Models;
using TMCollections_Api.Services.Interfaces.Repositories;
using TMCollections_Api.Services_New.Interfaces;

namespace TMCollections_Api.Services_New.Implementations
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateCategoryDto dto)
        {
            var existing = await _repo.GetByNameAsync(dto.Name);
            if (existing != null)
                throw new Exception("Category already exists");

            var category = _mapper.Map<Category>(dto);
            await _repo.AddAsync(category);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = _repo.GetByIdAsync(id);

            if (category == null)
                throw new Exception("Category not found");

             _repo.Delete(await category);
            await _repo.SaveChangesAsync();

        }

        public async Task< IEnumerable<CategoryDto> > GetAllAsync()
        {
            var categories= await _repo.GetAllWithProductsAsync();
            return   _mapper.Map<IEnumerable<CategoryDto>>(categories);

        }

        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            var category= await _repo.GetByIdAsync(id);
            return category==null ? null : _mapper.Map<CategoryDto>(category);
        }

        
    }
}
