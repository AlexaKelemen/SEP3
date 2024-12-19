package Shared.Database.Implementation;

import Shared.Database.DAOInterface.ItemCategoryDAOInterface;
import Shared.Database.DatabaseFactory;

import java.sql.*;
import java.util.ArrayList;
/**
 * Handles database operations related to the item-category relationship.
 */
public class ItemCategoryDAO extends DatabaseFactory implements
    /** Singleton instance of the ItemCategoryDAO class. */
    ItemCategoryDAOInterface
{
  public static ItemCategoryDAO instance;
  /**
   * Private constructor to enforce singleton pattern.
   * Registers the PostgreSQL driver.
   *
   * @throws SQLException if an error occurs during driver registration.
   */
  private ItemCategoryDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }

  /**
   * Returns the singleton instance of the ItemCategoryDAO class.
   *
   * @return ItemCategoryDAO instance.
   */
  public static synchronized ItemCategoryDAO getInstance()
  {
    try
    {
      if(instance == null)
      {
        instance = new ItemCategoryDAO();
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
   * Adds a relationship between an item and a category in the database.
   *
   * @param itemId the ID of the item.
   * @param categoryId the ID of the category.
   */
  @Override public synchronized void addItemCategory(int itemId, int categoryId)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("insert into item_category (item_id, category_id) VALUES (?,?);");
      statement.setInt(1, itemId);
      statement.setInt(2, categoryId);
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while adding into the shared item category table in the database: " + e.getMessage());
    }
  }

  /**
   *  Deletes a relationship between an item and a category from the database
   *
   * @param itemId the unique ID of the item.
   * @param categoryId the unique ID of the category.
   */

  @Override public void deleteItemCategory(int itemId, int categoryId)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("DELETE FROM item_category\n"
          + "WHERE item_id = ? and category_id = ?;");
      statement.setInt(1, itemId);
      statement.setInt(2, categoryId);
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while deleting from the shared item category table in the database: " + e.getMessage());
    }
  }
  /**
   * Retrieves a specific item-category relationship from the database.
   *
   * @param itemId the ID of the item.
   * @param categoryId the ID of the category.
   * @return the item ID and category ID, or null if not found.
   */
  @Override public int[] getItemCategory(int itemId, int categoryId)
  {
    int[] response = null;
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT item_id, category_id\n"
          + "FROM item_category\n" + "WHERE item_id = ? and category_id = ?;");
      statement.setInt(1, itemId);
      statement.setInt(2, categoryId);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        response = new int[2];
        response[0] = rs.getInt("item_id");
        response[1] = rs.getInt("category_id");
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting item categories from the database: " + e.getMessage());
    }
    return response;
  }

  /**
 * Retrieves all categories associated with a specific item.
 *
 * @param itemId the ID of the item.
 * @return a list of arrays, each containing the item ID and category ID.
 */
  @Override public ArrayList<int[]> getCategoriesForItem(int itemId)
  {
    ArrayList<int[]> response = new ArrayList<>();
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT item_id, category_id\n"
          + "FROM item_category\n" + "WHERE item_id = ?;");
      statement.setInt(1, itemId);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        int[] element = new int[2];
        element[0] = rs.getInt("item_id");
        element[1] = rs.getInt("category_id");
        response.add(element);
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting categories for an item from the database: " + e.getMessage());
    }
    return response;
  }

  /**
   * Retrieves all items associated with a specific category.
   *
   * @param categoryId the ID of the category.
   * @return a list of arrays, each containing the item ID and category ID.
   */
  @Override public ArrayList<int[]> getItemsForCategory(int categoryId)
  {
    ArrayList<int[]> response = new ArrayList<>();
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT item_id, category_id\n"
          + "FROM item_category\n" + "WHERE category_id = ?;");
      statement.setInt(1, categoryId);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        int[] element = new int[2];
        element[0] = rs.getInt("item_id");
        element[1] = rs.getInt("category_id");
        response.add(element);
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting categories for an item from the database: " + e.getMessage());
    }
    return response;
  }
}
