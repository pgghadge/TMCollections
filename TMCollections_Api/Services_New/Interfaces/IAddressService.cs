using TMCollections_Api.DTO.Address;

namespace TMCollections_Api.Services_New.Interfaces
{
    public interface IAddressService
    {
        Task<List<AddressDto>> GetUserAddressesAsync(Guid userId);
        Task<AddressDto?> GetAddressByIdAsync(Guid addressId);
        Task CreateAddressAsync(Guid userId, CreateAddressDto dto);
        Task UpdateAddressAsync(Guid addressId, UpdateAddressDto dto);
        Task DeleteAddressAsync(Guid addressId);
    }
}
