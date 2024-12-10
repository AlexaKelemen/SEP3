using System.ComponentModel;
using Entities;

namespace BlazorApp1.Managers;

public interface ICartManager: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public Dictionary<Item, int> cart { get; set; }
    void AddToCart(Item addedItem, int quantity);
    void RemoveFromCart(Item removedItem, int quantity);
    void ClearCart();
    float GetTotal();
    Dictionary<Item, int> GetCartItems();
    void PurchaseItems();
}