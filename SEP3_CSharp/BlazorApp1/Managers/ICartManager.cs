using Entities;

namespace BlazorApp1.Managers;

public interface ICartManager
{
    void AddToCartAsync(Item addedItem, int quantity);
    void RemoveFromCartAsync(Item removedItem, int quantity);
    void ClearCartAsync();
    float GetTotalAsync();
}