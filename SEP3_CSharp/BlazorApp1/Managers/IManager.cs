using DataTransferObjects;
using Entities;
using Entities.Utilities;

namespace BlazorApp1.Managers;

public interface IManager
{
    public ICartManager CartManager { get;}
    Task<User> GetUserAsync(string username);
    Task SaveUserInfoAsync(UserDTO userdto);
    Task<ItemDTOs> GetProductByIdAsync(int id);
    Task <IEnumerable<ItemDTOs>> GetItemsAsync();
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Dictionary<Item, int> GetCartItems();
    void AddToCart(Item addedItem, int quantity);
}