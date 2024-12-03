using DataTransferObjects;

namespace BlazorApp1.Services.Contracts;

public interface ICartService
{
    Task<CartItemDTO?> AddItem(CartItemToAddDTO cartItemToAddDto);
    Task<CartItemDTO?> DeleteItem(int id);

    Task<List<CartItemDTO>?> GetItems(int userId);
    //Task<CartItemDTO?> UpdateQty(CartItemQtyUpdateDTO cartItemQtyUpdateDto);
    event Action<int> OnCartChanged;
    void RaiseEventOnCartChanged(int totalQty);

}