using Microsoft.EntityFrameworkCore;
using TMCollections_Api.Data;
using TMCollections_Api.Models;

namespace TMCollections_Api.Services.Interfaces.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Address>> GetAddressesByUserAsync(Guid userId)
        {
            return  await _dbSet
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
    }
}
