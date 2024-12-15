package Shared.Database.DAOInterface;

import Shared.Entities.Item;

import java.util.ArrayList;

public interface ItemDAOInterface
{
  public Item addItem(Item item);
  public Item editItem(Item item);
  public void deleteItem(int itemId);
  public Item getItem(int itemId);
  public ArrayList<Item> getAllItems();
}
