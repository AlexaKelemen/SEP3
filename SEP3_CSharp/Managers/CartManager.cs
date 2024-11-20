using Entities;
using Managers.Server;

namespace Managers;

public class CartManager : ICartManager
{
    Dictionary<Item, int> cart = new Dictionary<Item, int>();
    
    public void AddToCart(Item addedItem, int quantity)
    {
        foreach (var item in cart)
        {
            if (item.Key.equals(addedItem) )
            {
                item.Value += quantity;
            }
        }
    }
}