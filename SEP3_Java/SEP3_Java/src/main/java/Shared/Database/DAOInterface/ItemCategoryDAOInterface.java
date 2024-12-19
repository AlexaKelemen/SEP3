package Shared.Database.DAOInterface;

import java.util.ArrayList;
/**
 * Interface for managing relationships between items and categories in the database.
 * <p>
 * This interface defines methods to create, delete, and retrieve the associations
 * between items and categories, as well as retrieve items by category or categories by item.
 * </p>
 */
public interface ItemCategoryDAOInterface
{
  /**
   * Adds an association between an item and a category in the database.
   *
   * @param itemId the unique ID of the item.
   * @param categoryId the unique ID of the category.
   */
  public void addItemCategory(int itemId, int categoryId);
  /**
   * Deletes an association between an item and a category in the database.
   *
   * @param itemId the unique ID of the item.
   * @param categoryId the unique ID of the category.
   */
  public void deleteItemCategory(int itemId, int categoryId);

  /**
   * Retrieves the association between a specific item and a category.
   *
   * @param itemId     the unique ID of the item.
   * @param categoryId the unique ID of the category.
   * @return an array of two integers, where the first element is the item ID and
   * the second element is the category ID
   */
  public int[] getItemCategory(int itemId, int categoryId);
  /**
   * Retrieves all categories associated with a specific item.
   *
   * @param itemId the unique ID of the item.
   * @return an {@link ArrayList} of integer arrays, where each array contains two integers:
   *         the item ID and the associated category ID.
   */
  public ArrayList<int[]> getCategoriesForItem(int itemId);
  /**
   * Retrieves all items associated with a specific category.
   *
   * @param categoryId the unique ID of the category.
   * @return an {@link ArrayList} of integer arrays, where each array contains two integers:
   *         the category ID and the associated item ID.
   */
  public ArrayList<int[]> getItemsForCategory(int categoryId);
}
