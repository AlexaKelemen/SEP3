package Shared.Database.Implementation;

import Shared.Database.DAOInterface.ItemDAOInterface;
import Shared.Database.DatabaseFactory;
import Shared.Entities.Item;

import java.math.BigDecimal;
import java.sql.*;
import java.util.ArrayList;

public class ItemDAO extends DatabaseFactory implements ItemDAOInterface
{
  public static ItemDAO instance;

  private ItemDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }

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
