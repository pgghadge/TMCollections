using TMCollections_Api.Models;

namespace TMCollections_Api.Services.Interfaces.Repositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);

        Task<User?> GetByIdAsync(Guid id);


    }
}
