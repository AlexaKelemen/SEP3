package Shared.Database.Implementation;

import Shared.Database.DAOInterface.ItemsInOrderDAOInterface;
import Shared.Database.DatabaseFactory;
import Shared.Entities.Item;

import java.sql.*;
import java.util.ArrayList;
/**
 * Handles database operations related to Items in Orders.
 */
public class ItemsInOrderDAO extends DatabaseFactory
    implements ItemsInOrderDAOInterface
{
  /** Singleton instance of the ItemsInOrderDAO class. */
  public static ItemsInOrderDAO instance;
  /**
   * Private constructor to enforce singleton pattern.
   * Registers the PostgreSQL  driver.
   *
   * @throws SQLException if an error occurs during driver registration.
   */
  private ItemsInOrderDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }
  /**
   * Returns the singleton instance of the ItemsInOrderDAO class.
   *
   * @return ItemsInOrderDAO instance.
   */
  public static synchronized ItemsInOrderDAO getInstance()
  {
    try
    {
      if (instance == null)
      {
        instance = new ItemsInOrderDAO();
      }
      return instance;
    }
    catch (SQLException e)
    {
      e.printStackTrace();
      return null;
    }
  }

  /**
   * Adds an item to the order
   * @param item    the Item object to be added to the order.
   * @param orderId the unique ID of the order to which the item will be added.
   * @return the updated order with the new item in it
   */
  @Override public Item addItemToOrder(Item item, int orderId)
  {
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement(
          "insert into Items_in_Order(item_id, order_id, item_quantity, item_colour, item_size) VALUES (?,?,?,?,?);");
      statement.setInt(1, item.getItemId());
      statement.setInt(2, orderId);
      statement.setInt(3, item.getQuantity());
      statement.setString(4, item.getColour());
      statement.setString(5, item.getSize());
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while adding an item to an order in the database: " + e.getMessage());
    }
    return getItemInOrder(item, orderId);
  }

  /**
   * Edits the details of an item from an order in the database
   *
   * @param item the Item object containing updated information
   * @param orderId the unique identifier of the order in which the item exists
   * @return the order with the updated item in it
   */
  @Override public Item editItemInOrder(Item item, int orderId)
  {
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("UPDATE Items_in_Order\n"
          + "SET item_quantity = ?, item_colour = ?, item_size = ?\n"
          + "WHERE item_id = ? and order_id = ?;");
      statement.setInt(1, item.getQuantity());
      statement.setString(2, item.getColour());
      statement.setString(3, item.getSize());
      statement.setInt(4, item.getItemId());
      statement.setInt(5, orderId);
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while editing an item in an order in the database: " + e.getMessage());
    }
    return getItemInOrder(item, orderId);
  }

  /**
   * Deletes an item from an order in the database
   *
   * @param itemId the unique identifier of the item that gets deleted
   * @param orderId the unique identifier of the order in which the item gets deleted
   */

  @Override public void deleteItemFromOrder(int itemId, int orderId)
  {
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("DELETE FROM Items_in_Order\n"
          + "WHERE item_id = ? and order_id = ?;");
      statement.setInt(1, itemId);
      statement.setInt(2, orderId);
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while deleting an item from the database: " + e.getMessage());
    }
  }

  /**
   * Retrieves an item from an order in the database using its id
   *
   * @param item    the  Item object to be retrieved
   * @param orderId the unique ID of the order containing the item.
   * @return
   */

  @Override public Item getItemInOrder(Item item, int orderId)
  {
    Item response = null;
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT item_quantity, item_colour, item_size\n"
          + "FROM Items_in_Order\n" + "WHERE item_id = ? and order_id = ?;");
      statement.setInt(1, item.getItemId());
      statement.setInt(2, orderId);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        response = new Item(item.getName(), item.getCategory(), item.getPrice(), item.getItemId(), item.getDescription(), rs.getInt("item_quantity"), rs.getString("item_colour"), rs.getString("item_size"));
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting an item for an order from the database: " + e.getMessage());
    }
    return response;
  }
  /**
   * Retrieves all items in an order from the database.
   *
   * @param orderId the ID of the order.
   * @return a list of Item objects representing the items in the order.
   */
  @Override public ArrayList<Item> getAllItemsInOrder(int orderId)
  {
    ArrayList<Item> response = new ArrayList<>();
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT item_id, item_quantity, item_colour, item_size\n"
          + "FROM Items_in_Order\n" + "WHERE order_id = ?;");
      statement.setInt(1, orderId);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        Item element = new Item();
        element.setItemId(rs.getInt("item_id"));
        element.setQuantity(rs.getInt("item_quantity"));
        element.setColour(rs.getString("item_colour"));
        element.setSize(rs.getString("item_size"));
        response.add(element);
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting items for an order from the database: " + e.getMessage());
    }
    return response;
  }
}
