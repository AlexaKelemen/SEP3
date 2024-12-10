using System.ComponentModel;
using Entities;


namespace BlazorApp1.Managers;

public class CartManager : ICartManager, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    Dictionary<Item, int> cart = new Dictionary<Item, int>();
    
    public void AddToCart(Item addedItem, int quantity)
    {
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
        
    }

    
    protected void OnPropertyChanged(string name)
    {
        
    }
}