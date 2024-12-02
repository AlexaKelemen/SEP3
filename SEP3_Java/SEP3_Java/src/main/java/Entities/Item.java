package Entities;

import Utlities.Category;

public class Item
{
  private String itemtype;
  private double price;
  private String description;
  private String name;
  private Category category;

  private String ImageURL;

  public Item(String name, Category category, double price, String ImageURL)
  {
    this.name = name;
    this.category = category;
    this.price = price;
    this.ImageURL = ImageURL;
  }

  public String getName()
  {
    return name;
  }

  public void setName(String name)
  {
    this.name = name;
  }

  public double getPrice()
  {
    return price;
  }

  public void setPrice(double price)
  {
    this.price = price;
  }

  public Category getCategory()
  {
    return category;
  }

  public void setCategory(Category category)
  {
    this.category = category;
  }

  public String getDescription()
  {
    return description;
  }

  public void setDescription(String description)
  {
    this.description = description;
  }

  public String getItemtype()
  {
    return itemtype;
  }

  public void setItemtype(String itemtype)
  {
    this.itemtype = itemtype;
  }

  public String getImageURL(){
    return ImageURL;
  }

  public void setImageURL(String imageURL) {
    ImageURL = imageURL;
  }
}
