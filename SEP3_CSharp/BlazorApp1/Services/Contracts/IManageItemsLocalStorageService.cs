using System.Collections.Generic;
using System.Threading.Tasks;
using DataTransferObjects;

public interface IManageItemsLocalStorageService
{
    Task<List<ItemDTOs>> GetCollection(); // Retrieve the product collection
    Task SaveCollection(List<ItemDTOs> products); // Save the product collection
}