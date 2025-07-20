using Microsoft.EntityFrameworkCore;
using TMCollections_Api.Data;
using TMCollections_Api.Models;

namespace TMCollections_Api.Services.Interfaces.Repositories
{
    public class CartRepository : GenericRepository<Cart>, IICartRepository
    {
        public CartRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddCartAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
        }

        public async  Task<Cart?> GetCartByUserIdAsync(Guid userId)
        {
                return await _context.Carts
                    .Include(c => c.CartItems)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            _context.Carts.Update(cart);
        }

        public async Task DeleteCartAsync(Guid cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);
            if (cart != null)
                _context.Carts.Remove(cart);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
