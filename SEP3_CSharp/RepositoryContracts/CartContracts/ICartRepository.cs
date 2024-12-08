using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace RepositoryContracts.CartContracts
{
    public interface ICartRepository
    {
        Task<Cart> AddItemToCartAsync(int cartId, Item item);


        Task RemoveItemFromCartAsync(int cartId, int itemId);


        Task<Cart> GetSingleCartAsync(int cartId);


        IQueryable<Cart> GetCarts();


        Task ClearCartAsync(int cartId);


        Task<IQueryable<Item>> GetItemsInCartAsync(int cartId);
    }
}