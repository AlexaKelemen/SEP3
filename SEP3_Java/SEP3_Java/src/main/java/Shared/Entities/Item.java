package Shared.Entities;

import Shared.Entities.Utlities.Category;

import java.util.ArrayList;

public class Item
{
  private String name;
  private ArrayList<Category> category;
  private double price;
  private int itemId;
  private String description;
  private int quantity;
  private String colour;

  public Item(String name, ArrayList<Category> category, double price)
  {
    this.name = name;
    this.category = category;
    this.price = price;
  }

  public Item(String name, ArrayList<Category> category, double price, int itemId, String description, int quantity, String colour)
  {
    this.name = name;
    this.category = category;
    this.price = price;
    this.itemId = itemId;
    this.description = description;
    this.quantity = quantity;
    this.colour = colour;
  }

  public Item() {}

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

  public ArrayList<Category> getCategory()
  {
    return category;
  }

  public void setCategory(ArrayList<Category> category)
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

  public int getItemId()
  {
    return itemId;
  }

  public void setItemId(int itemId)
  {
    this.itemId = itemId;
  }

  public int getQuantity(){
    return quantity;
  }

  public void setQuantity(int quantity) {
    this.quantity = quantity;
  }

  public String getColour(){return colour;}

  public void setColour(String colour) {this.colour = colour;}
}
