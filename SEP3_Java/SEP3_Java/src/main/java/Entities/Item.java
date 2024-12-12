package Entities;

import Utlities.Category;

import java.util.ArrayList;

public class Item
{
  private int itemId;
  private double price;
  private String description;
  private String name;
  private ArrayList<Category> category;
  private int quantity;
  private String colour;

  public Item(String name, ArrayList<Category> category, double price)
  {
    this.name = name;
    this.category = category;
    this.price = price;
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

  public int getItemtype()
  {
    return itemId;
  }

  public void setItemtype(int itemtype)
  {
    this.itemId = itemtype;
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
