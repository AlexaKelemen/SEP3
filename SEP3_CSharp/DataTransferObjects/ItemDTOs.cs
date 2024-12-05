namespace DataTransferObjects;

public class ItemDTOs
{
    public int itemId;
    public String name;
    public String description;
    public double price;
    public int quantity;
    public int categoryId;
    public String categoryName;
    public String imageURL;

    public ItemDTOs()
    {
    }

    public ItemDTOs(int itemId, String name, String description, double price, int quantity, int categoryId,
        String categoryName, String imageURL)
    {
        this.itemId = itemId;
        this.name = name;
        this.description = description;
        this.price = price;
        this.quantity = quantity;
        this.categoryId = categoryId;
        this.categoryName = categoryName;
        this.imageURL = imageURL;
    }
}