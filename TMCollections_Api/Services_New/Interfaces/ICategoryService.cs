using TMCollections_Api.DTO.Category;

namespace TMCollections_Api.Services_New.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateCategoryDto dto);
        //Task UpdateAsync(Guid id, UpdateCategoryDto dto);
        Task DeleteAsync(Guid id);
    }
}
