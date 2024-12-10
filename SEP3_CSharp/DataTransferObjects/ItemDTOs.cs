using Entities.Utilities;

namespace DataTransferObjects;

public class ItemDTOs
{
    public int ItemId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public float Price{get;set;}
    public List<Category> CategoryId { get; set; } = new List<Category>();
    public string ImageUrl{get;set;}

    public ItemDTOs()
    {
    }
    public ItemDTOs(int itemId, string name, string description, float price, int quantity, List<Category> categoryId,
        string imageURL)
    {
        this.ItemId = itemId;
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.CategoryId = categoryId;
        this.ImageUrl = imageURL;
    }

    public bool HasCategory(string category)
    {
        foreach (var categoryid in CategoryId)
        {
            if (category == categoryid.CategoryName)
                return true;
        }
        return false;
    }
}