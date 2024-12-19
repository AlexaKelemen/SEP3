package Shared.Database.DAOInterface;

import Shared.Entities.Item;

import java.util.ArrayList;
/**
 * Interface for managing item-related database operations.
 * <p>
 * This interface defines methods for creating, updating, deleting, and retrieving
 * items in the database, as well as retrieving all items at once.
 * </p>
 */

public interface ItemDAOInterface
{
  /**
   * Adds a new item to the database
   *
   * @param item the item to be added to the database
   * @return the added Item object
   */
  public Item addItem(Item item);

  /**
   * Edits an existing item in the database
   *
   * @param item the item with the updated information
   * @return the updated Item object
   */
  public Item editItem(Item item);

  /**
   * Deletes an item from the database
   * @param itemId the unique identifier of the object that is to be deleted from the database
   */
  public void deleteItem(int itemId);

  /**
   * Retrieves a specific item from the database using its id
   * @param itemId the unique identifier of the item that is retrieved from the database
   * @return the object corresponding to the id
   */
  public Item getItem(int itemId);

  /**
   * Retrieves a list with all the items from the database
   * @return a list with all the items available from the database
   */
  public ArrayList<Item> getAllItems();
}
