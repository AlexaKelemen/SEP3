namespace DataTransferObjects;

public class ItemDTOs
{
    public int ItemId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public float Price{get;set;}
    public int Quantity{get;set;}
    public int CategoryId{get;set;}
    public string CategoryName{get;set;}
    public string ImageUrl{get;set;}

    public ItemDTOs()
    {
    }
    public ItemDTOs(int itemId, string name, string description, float price, int quantity, int categoryId,
        string categoryName, string imageURL)
    {
        this.ItemId = itemId;
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.Quantity = quantity;
        this.CategoryId = categoryId;
        this.CategoryName = categoryName;
        this.ImageUrl = imageURL;
    }
}