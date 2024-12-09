using System.Linq;
using System.Threading.Tasks;
using DatabaseConnection;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace RepositoryContracts.CartContracts
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> AddItemToCartAsync(int cartId, Item item)
        {
            var cart = await _context.Carts.Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart == null)
                throw new KeyNotFoundException(
                    $"Cart with ID {cartId} not found.");

            cart.Items.Add(item);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task RemoveItemFromCartAsync(int cartId, int itemId)
        {
            var cart = await _context.Carts.Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart == null)
                throw new KeyNotFoundException(
                    $"Cart with ID {cartId} not found.");

            var item = cart.Items.FirstOrDefault(i => i.ItemId == itemId);
            if (item == null)
                throw new KeyNotFoundException(
                    $"Item with ID {itemId} not found in cart.");

            cart.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetSingleCartAsync(int cartId)
        {
            var cart = await _context.Carts.Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart == null)
                throw new KeyNotFoundException(
                    $"Cart with ID {cartId} not found.");

            return cart;
        }

        public IQueryable<Cart> GetCarts()
        {
            return _context.Carts.Include(c => c.Items).AsQueryable();
        }

        public async Task ClearCartAsync(int cartId)
        {
            var cart = await _context.Carts.Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart == null)
                throw new KeyNotFoundException(
                    $"Cart with ID {cartId} not found.");

            cart.Items.Clear();
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<Item>> GetItemsInCartAsync(int cartId)
        {
            var cart = await _context.Carts.Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart == null)
                throw new KeyNotFoundException(
                    $"Cart with ID {cartId} not found.");

            return cart.Items.AsQueryable();
        }
    }
}