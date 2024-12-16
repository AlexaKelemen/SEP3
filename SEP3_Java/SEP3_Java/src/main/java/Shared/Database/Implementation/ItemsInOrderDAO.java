package Shared.Database.Implementation;

import Shared.Database.DAOInterface.ItemsInOrderDAOInterface;
import Shared.Database.DatabaseFactory;
import Shared.Entities.Item;

import java.sql.*;
import java.util.ArrayList;

public class ItemsInOrderDAO extends DatabaseFactory
    implements ItemsInOrderDAOInterface
{
  public static ItemsInOrderDAO instance;

  private ItemsInOrderDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }

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

  @Override public Item addItemToOrder(Item item, int orderId)
  {
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement(
          "insert into items_in_order(item_id, order_id, item_quantity, item_colour) VALUES (?,?,?,?);");
      statement.setInt(1, item.getItemId());
      statement.setInt(2, orderId);
      statement.setInt(3, item.getQuantity());
      statement.setString(4, item.getColour());
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while adding an item to an order in the database: " + e.getMessage());
    }
    return getItemInOrder(item, orderId);
  }

  @Override public Item editItemInOrder(Item item, int orderId)
  {
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("UPDATE Items_in_Order\n"
          + "SET  item_quantity = ?, item_colour = ?\n"
          + "WHERE item_id = ? and order_id = ?;");
      statement.setInt(1, item.getQuantity());
      statement.setString(2, item.getColour());
      statement.setInt(3, item.getItemId());
      statement.setInt(4, orderId);
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while editing an item in an order in the database: " + e.getMessage());
    }
    return getItemInOrder(item, orderId);
  }

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

  @Override public Item getItemInOrder(Item item, int orderId)
  {
    Item response = null;
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT item_quantity, item_colour\n"
          + "FROM Items_in_Order\n" + "WHERE item_id = ? and order_id = ?;");
      statement.setInt(1, item.getItemId());
      statement.setInt(2, orderId);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        response = new Item(item.getName(), item.getCategory(), item.getPrice(), item.getItemId(), item.getDescription(), rs.getInt("item_quantity"), rs.getString("item_colour"));
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting an item for an order from the database: " + e.getMessage());
    }
    return response;
  }

  @Override public ArrayList<Item> getAllItemsInOrder(int orderId)
  {
    ArrayList<Item> response = new ArrayList<>();
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT item_id, item_quantity, item_colour\n"
          + "FROM Items_in_Order\n" + "WHERE order_id = ?;");
      statement.setInt(1, orderId);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        Item element = new Item();
        element.setItemId(rs.getInt("item_id"));
        element.setQuantity(rs.getInt("item_quantity"));
        element.setColour(rs.getString("item_colour"));
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
