package Shared.Database.DAOInterface;

import Shared.Entities.Order;

import java.util.ArrayList;
/**
 * Interface for managing order-related database operations.
 * <p>
 * This interface defines methods for creating, updating, deleting, and retrieving
 * orders in the database, as well as retrieving all orders.
 * </p>
 */
public interface OrderDAOInterface
{
  /**
   * Adds a new order to the database.
   *
   * @param order the  Order object to be added.
   * @return the added  Order object
   */
  public Order addOrder(Order order);
  /**
   * Updates an existing order in the database.
   *
   * @param order the Order object containing updated information.
   * @return the updated Order object.
   */
  public Order editOrder(Order order);

  /**
   * Deletes an order from the database using its ID.
   *
   * @param orderId the unique ID of the order to be deleted.
   */
  public void deleteOrder(int orderId);

  /**
   * Retrieves a specific order from the database using its ID.
   *
   * @param orderId the unique ID of the order to retrieve.
   * @return the  Order object corresponding to the given ID, or null if no such order exists.
   */
  public Order getOrder(int orderId);

  /**
   * Retrieves all orders available in the database.
   *
   * @return an  ArrayList of  Order objects representing all orders.
   */
  public ArrayList<Order> getAllOrders();
}
