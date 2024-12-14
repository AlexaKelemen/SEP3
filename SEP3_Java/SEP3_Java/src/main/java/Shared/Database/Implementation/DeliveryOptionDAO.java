package Shared.Database.Implementation;

import Shared.Database.DAOInterface.DeliveryOptionDAOInterface;
import Shared.Database.DatabaseFactory;
import Shared.Entities.Utlities.DeliveryOption;

import java.sql.*;
import java.util.ArrayList;

public class DeliveryOptionDAO extends DatabaseFactory implements DeliveryOptionDAOInterface
{
  public static DeliveryOptionDAO instance;

  private DeliveryOptionDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }

  public synchronized static DeliveryOptionDAO getInstance()
  {
    try
    {
      if(instance == null)
      {
        instance = new DeliveryOptionDAO();
      }
      return instance;
    }
    catch (SQLException e)
    {
      e.printStackTrace();
      return null;
    }
  }
  @Override public synchronized DeliveryOption addDeliveryOption(DeliveryOption deliveryOption)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("insert into Delivery_Options(name) values (?);");
      statement.setString(1, deliveryOption.getName());
      statement.executeUpdate();
      ResultSet generatedKeys = statement.getGeneratedKeys();
      if(generatedKeys.next())
      {
        deliveryOption.setId(generatedKeys.getInt("id"));
      }
      else
      {
        throw new RuntimeException("No keys were generated.");
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while adding a delivery option to the database:" + e.getMessage());
    }
    return getDeliveryOption(deliveryOption.getId());
  }

  @Override public synchronized DeliveryOption editDeliveryOption(DeliveryOption deliveryOption)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("UPDATE Delivery_Options\n"
          + "SET name = ?\n" + "WHERE id = ?;");
      statement.setString(1, deliveryOption.getName());
      statement.setInt(2, deliveryOption.getId());
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while editing a delivery option in the database: " + e.getMessage());
    }
    return getDeliveryOption(deliveryOption.getId());
  }

  @Override public synchronized void deleteDeliveryOption(int deliveryOptionId)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("DELETE FROM Delivery_Options\n"
          + "WHERE id = ?;");
      statement.setInt(1, deliveryOptionId);
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while deleting a delivery option from the database: " + e.getMessage());
    }
  }

  @Override public DeliveryOption getDeliveryOption(int deliveryOptionId)
  {
    DeliveryOption response = new DeliveryOption();
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT id, name\n"
          + "FROM Delivery_Options\n" + "WHERE id = ?;");
      statement.setInt(1, deliveryOptionId);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        response.setId(rs.getInt("id"));
        response.setName(rs.getString("name"));
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting a delivery option from the database: " + e.getMessage());
    }
    return response;
  }

  @Override public ArrayList<DeliveryOption> getAllDeliveryOptions()
  {
    ArrayList<DeliveryOption> response = new ArrayList<>();
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT id, name\n"
          + "FROM Delivery_Options;");
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        DeliveryOption element = new DeliveryOption();
        element.setId(rs.getInt("id"));
        element.setName(rs.getString("name"));
        response.add(element);
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting the delivery options from the database: " + e.getMessage());
    }
    return response;
  }
}
