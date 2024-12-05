namespace DataTransferObjects;

public class ItemDTOs
{
    public int ItemId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public double Price{get;set;}
    public int Quantity{get;set;}
    public int CategoryId{get;set;}
    public String CategoryName{get;set;}
    public String ImageUrl{get;set;}

    public ItemDTOs()
    {
    }
    public ItemDTOs(int itemId, String name, String description, double price, int quantity, int categoryId,
        String categoryName, String imageURL)
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