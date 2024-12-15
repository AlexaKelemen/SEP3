package Shared.Database.DAOInterface;

import Shared.Entities.Item;

import java.util.ArrayList;

public interface ItemsInOrderDAOInterface
{
  public Item addItemToOrder(Item item, int orderId);
  public Item editItemInOrder(Item item, int orderId);
  public void deleteItemFromOrder(int itemId, int orderId);
  public Item getItemInOrder(Item item, int orderId);
  public ArrayList<Item> getAllItemsInOrder(int orderId);
}
