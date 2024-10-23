package Utlities;
import Entities.Item;

public class OrderItem
{
  private Item item;
  private int quantity;
  private double subtotal;

  public OrderItem(Item item, int quantity)
  {
    this.item = item;
    this.quantity = quantity;
  }

  

}
