using System.Collections.Generic;
using System.Threading.Tasks;
using DataTransferObjects;

public interface IManageCartItemsLocalStorageService
{
    Task<List<CartItemDTO>> GetCollection(); // Retrieve the cart items
    Task SaveCollection(List<CartItemDTO> cartItems); // Save the cart items
}