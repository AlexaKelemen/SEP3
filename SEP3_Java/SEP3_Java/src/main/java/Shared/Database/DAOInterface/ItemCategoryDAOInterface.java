package Shared.Database.DAOInterface;

import java.util.ArrayList;

public interface ItemCategoryDAOInterface
{
  public void addItemCategory(int itemId, int categoryId);
  public void deleteItemCategory(int itemId, int categoryId);
  public int[] getItemCategory(int itemId, int categoryId);
  public ArrayList<int[]> getCategoriesForItem(int itemId);
  public ArrayList<int[]> getItemsForCategory(int categoryId);
}
