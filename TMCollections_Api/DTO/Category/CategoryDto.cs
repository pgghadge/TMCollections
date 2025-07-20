using TMCollections_Api.DTO.Product;

namespace TMCollections_Api.DTO.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<ProductDto> Products { get; set; }

    }
}
