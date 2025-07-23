using TMCollections_Api.Models;

namespace TMCollections_Api.Services.Interfaces.Repositories
{
    public interface IAddressRepository:IGenericRepository<Address>
    {
        Task<List<Address>> GetAddressesByUserAsync(Guid userId);
    }
}
