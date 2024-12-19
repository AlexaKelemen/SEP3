package Shared.Database.DAOInterface;

import Shared.Entities.Item;

import java.util.ArrayList;
/**
 * Interface for managing items within orders in the database.
 * <p>
 * This interface defines methods for adding, updating, deleting, and retrieving
 * items associated with specific orders, as well as retrieving all items in a particular order.
 * </p>
 */
public interface ItemsInOrderDAOInterface
{
  /**
   * Adds an item to a specific order in the database.
   *
   * @param item    the Item object to be added to the order.
   * @param orderId the unique ID of the order to which the item will be added.
   * @return the added Item object, potentially including any updated fields such as an order-specific ID.
   */
  public Item addItemToOrder(Item item, int orderId);

  /**
   * Edits an existing order from the database
   *
   * @param item the Item object containing updated information
   * @param orderId the unique identifier of the order in which the item exists
   * @return the updated Item object
   */
  public Item editItemInOrder(Item item, int orderId);

  /**
   * Deletes an item from an existing order
   * @param itemId the unique identifier of the item that gets deleted
   * @param orderId the unique identifier of the order in which the item gets deleted
   */
  public void deleteItemFromOrder(int itemId, int orderId);

  /**
   * Retrieves a specific item from a specific order in the database.
   *
   * @param item    the  Item object to be retrieved
   * @param orderId the unique ID of the order containing the item.
   * @return the  Item object found in the specified order, or null if no matching item exists.
   */
  public Item getItemInOrder(Item item, int orderId);

  /**
   * Retrieves all items in a specific order from the database.
   *
   * @param orderId the unique ID of the order whose items will be retrieved.
   * @return an {@link ArrayList} of {@link Item} objects representing all items in the specified order.
   */
  public ArrayList<Item> getAllItemsInOrder(int orderId);
}
