package Shared.Database.Implementation;

import Shared.Database.DAOInterface.ItemCategoryDAOInterface;
import Shared.Database.DatabaseFactory;

import java.sql.*;
import java.util.ArrayList;

public class ItemCategoryDAO extends DatabaseFactory implements
    ItemCategoryDAOInterface
{
  public static ItemCategoryDAO instance;

  private ItemCategoryDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }

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
