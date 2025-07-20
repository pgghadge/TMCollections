using Microsoft.EntityFrameworkCore;
using TMCollections_Api.Data;
using TMCollections_Api.Models;

namespace TMCollections_Api.Services.Interfaces.Repositories
{
    public class CartItemRepository :  ICartItemRepository
    {
        private readonly AppDbContext _context;
        public CartItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddCartItemAsync(CartItem item)
        {
            await _context.CartItems.AddAsync(item);
        }

        public async Task DeleteCartItemAsync(CartItem item)
        {
            _context.CartItems.Remove(item);
        }

        public async Task<CartItem?> GetCartItemByIdAsync(Guid cartItemId)
        {
            return await _context.CartItems
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == cartItemId);
        }

        public async  Task<List<CartItem>> GetItemsByCartIdAsync(Guid cartId)
        {
            return await _context.CartItems
                .Where(i => i.CartId == cartId)
                .Include(i => i.Product)
                .ToListAsync();
        }

        public async Task UpdateCartItemAsync(CartItem item)
        {
            _context.CartItems.Update(item);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> CalculateCartTotalAsync(Guid cartId)
        {
            return await _context.CartItems
                .Where(ci => ci.CartId == cartId)
                .SumAsync(ci => ci.Price);
        }

        public async Task<List<CartItem>> GetCartItemsByCartIdAsync(Guid cartId)
        {
            return await _context.CartItems
                .Where(ci => ci.CartId == cartId)
                .ToListAsync();
        }




    }
}
