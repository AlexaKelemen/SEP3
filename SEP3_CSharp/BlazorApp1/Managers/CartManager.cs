using System.ComponentModel;
using Entities;
using Entities.Utilities;


namespace BlazorApp1.Managers;

public class CartManager : ICartManager, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public Dictionary<Item, int> cart { get; set; }

    public CartManager()
    {
        cart = new Dictionary<Item, int>();
    }
    
    public void AddToCart(Item addedItem, int quantity)
    {
        if (cart == null)
        {
            cart = new Dictionary<Item, int>();
        }
        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity cannot be less or equal to zero");
        }
        if (cart.ContainsKey(addedItem))
        { 
            cart[addedItem] += quantity;  
        }
        else
        {
            cart.Add(addedItem, quantity);
        }
    }

    public void RemoveFromCart(Item removedItem, int quantity)
    {
        if (!cart.ContainsKey(removedItem))
        {
            throw new KeyNotFoundException("Item not found in cart");
        }

        if (quantity <= 0)
        {
           throw new ArgumentException("Quantity cannot be less or equal to zero"); 
        }

        if (cart[removedItem] > quantity)
        {
            cart[removedItem] -= quantity;
        }
        else
        {
            cart.Remove(removedItem);
        }
    }

    public void ClearCart()
    {
        cart.Clear();
    }

    public float GetTotal()
    {
        float totalPrice = 0;
        foreach (var item in cart)
        {
           totalPrice += item.Key.Price * item.Value;
        }
        return totalPrice;
    }

    public Dictionary<Item, int> GetCartItems()
    {
        return cart;
    }

    public void PurchaseItems()
    {
        OnPropertyChanged(nameof(cart));
    }

    
    protected void OnPropertyChanged(string name)
    {
        var handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(name));
    }
}