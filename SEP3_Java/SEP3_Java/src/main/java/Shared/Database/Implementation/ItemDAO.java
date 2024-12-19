package Shared.Database.Implementation;

import Shared.Database.DAOInterface.ItemDAOInterface;
import Shared.Database.DatabaseFactory;
import Shared.Entities.Item;

import java.math.BigDecimal;
import java.sql.*;
import java.util.ArrayList;
/**
 * Handles database operations related to Items.
 */
public class ItemDAO extends DatabaseFactory implements ItemDAOInterface
{
  /** Singleton instance of the ItemDAO class. */
  public static ItemDAO instance;
  /**
   * Private constructor to enforce singleton pattern.
   * Registers the PostgreSQL driver.
   *
   * @throws SQLException if an error occurs during driver registration.
   */
  private ItemDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }
  /**
   * Returns the singleton instance of the ItemDAO class.
   *
   * @return ItemDAO instance.
   */
  public static synchronized ItemDAO getInstance()
  {
    try
    {
      if(instance == null)
      {
        instance = new ItemDAO();
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
   * Adds an item to the database
   *
   * @param item the item to be added to the database
   * @return the item to be added to the database
   */
  @Override public synchronized Item addItem(Item item)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("insert into item(item_id, name, description, price) VALUES (?,?,?,?);");
      statement.setInt(1, item.getItemId());
      statement.setString(2, item.getName());
      statement.setString(3, item.getDescription());
      statement.setBigDecimal(4, new BigDecimal(item.getPrice()));
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while adding an item to the database: " + e.getMessage());
    }
    return getItem(item.getItemId());
  }

  /**
   * Edits an existing item from the database
   *
   * @param item the item with the updated information
   * @return the updated item
   */
  @Override public synchronized Item editItem(Item item)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("UPDATE item\n"
          + "SET name = ?, description = ?, price = ?\n" + "WHERE item_id = ?;");
      statement.setString(1, item.getName());
      statement.setString(2, item.getDescription());
      statement.setBigDecimal(3, new BigDecimal(item.getPrice()));
      statement.setInt(4, item.getItemId());
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while editing an item in the database: " + e.getMessage());
    }
    return getItem(item.getItemId());
  }

  /**
   * Deletes an item from the database
   * @param itemId the unique identifier of the object that is to be deleted from the database
   */

  @Override public synchronized void deleteItem(int itemId)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("DELETE FROM item\n"
          + "WHERE item_id = ?;");
      statement.setInt(1, itemId);
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while deleting an item from the database: " + e.getMessage());
    }
  }
  /**
   * Retrieves a specific item from the database by its ID.
   *
   * @param itemId the ID of the item to retrieve.
   * @return the Item object corresponding to the given ID, or null if not found.
   */
  @Override public Item getItem(int itemId)
  {
    Item response = null;
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT name, description, price\n"
          + "FROM item\n" + "WHERE item_id = ?;");
      statement.setInt(1, itemId);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        response = new Item();
        response.setItemId(itemId);
        response.setName(rs.getString("name"));
        response.setDescription(rs.getString("description"));
        response.setPrice(rs.getBigDecimal("price").doubleValue());
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException();
    }
    return response;
  }

  /**
   * Retrieves all items from the database.
   *
   * @return a list of all Item objects.
   */
  @Override public ArrayList<Item> getAllItems()
  {
    ArrayList<Item> response = new ArrayList<>();
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT item_id,name, description, price\n"
          + "FROM item;");
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        Item element = new Item();
        element.setItemId(rs.getInt("item_id"));
        element.setName(rs.getString("name"));
        element.setDescription(rs.getString("description"));
        element.setPrice(rs.getBigDecimal("price").doubleValue());
        response.add(element);
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException();
    }
    return response;
  }
}
