package Shared.Database.Implementation;

import Shared.Database.DAOInterface.DeliveryOptionDAOInterface;
import Shared.Database.DatabaseFactory;
import Shared.Entities.Utlities.DeliveryOption;

import java.sql.*;
import java.util.ArrayList;
/**
 * Handles database operations related to Delivery Options.
 */
public class DeliveryOptionDAO extends DatabaseFactory implements DeliveryOptionDAOInterface
{

  /** Singleton instance of the DeliveryOptionDAO class. */
  public static DeliveryOptionDAO instance;
  /**
   * Private constructor to enforce singleton pattern.
   * Registers the PostgreSQL driver.
   *
   * @throws SQLException if an error occurs during driver registration.
   */
  private DeliveryOptionDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }
  /**
   * Returns the singleton instance of the DeliveryOptionDAO class.
   *
   * @return DeliveryOptionDAO instance.
   */
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

  /**
   * Adds a new  delivery option to the database
   *
   * @param deliveryOption the deliveryOption object to be added.
   * @return the new delivery option
   */
  @Override public synchronized DeliveryOption addDeliveryOption(DeliveryOption deliveryOption)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("insert into Delivery_Options(name) values (?);", new String[]{"id"});
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

  /**
   * Edits an existing delivery option from the database
   *
   * @param deliveryOption the @link DeliveryOption object containing updated information.
   * @return the updated delivery option
   */

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

  /**
   * Deletes an existing delivery option from the database
   *
   * @param deliveryOptionId the identifier of the delivery option that is deleted
   */
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

  /**
   * Retrieves a specific delivery option from the database by its ID.
   *
   * @param deliveryOptionId  an identifier or criteria used to locate the delivery option
   @return the DeliveryOption object corresponding to the given ID, or null if not found
   */
  @Override public DeliveryOption getDeliveryOption(int deliveryOptionId)
  {
    DeliveryOption response = null;
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT id, name\n"
          + "FROM Delivery_Options\n" + "WHERE id = ?;");
      statement.setInt(1, deliveryOptionId);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        response = new DeliveryOption();
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

  /**
   * Retrieves all delivery options from the database.
   *
   * @return a list of all DeliveryOption objects.
   */

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
