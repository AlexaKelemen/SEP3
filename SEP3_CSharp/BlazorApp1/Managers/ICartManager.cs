using Entities;

namespace BlazorApp1.Managers;

public interface ICartManager
{
    void AddToCart(Item addedItem, int quantity);
    void RemoveFromCart(Item removedItem, int quantity);
    void ClearCart();
    float GetTotal();
}