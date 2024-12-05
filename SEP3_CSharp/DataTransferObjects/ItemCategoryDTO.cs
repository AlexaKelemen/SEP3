using Entities;
using Entities.Utilities;

namespace DataTransferObjects;

public class ItemCategoryDTO
{
    public Item ItemId { get; set; }
    public Category CategoryId { get; set; } 
    public string CategoryName { get; set; }
    
}