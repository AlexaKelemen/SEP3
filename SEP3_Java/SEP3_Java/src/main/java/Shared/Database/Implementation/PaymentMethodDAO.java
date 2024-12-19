package Shared.Database.Implementation;

import Shared.Database.DAOInterface.PaymentMethodDAOInterface;
import Shared.Database.DatabaseFactory;
import Shared.Entities.Utlities.PaymentMethod;

import java.sql.*;
import java.util.ArrayList;
/**
 * Handles database operations related to Payment Methods.
 */
public class PaymentMethodDAO extends DatabaseFactory implements PaymentMethodDAOInterface
{
  /** Singleton instance of the PaymentMethodDAO class. */
  public static PaymentMethodDAO instance;
  /**
   * Private constructor to enforce singleton pattern.
   * Registers the PostgreSQL driver.
   *
   * @throws SQLException if an error occurs during driver registration.
   */
  private PaymentMethodDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }
  /**
   * Returns the singleton instance of the PaymentMethodDAO class.
   *
   * @return PaymentMethodDAO instance.
   */
  public static synchronized PaymentMethodDAO getInstance()
  {
    try
    {
      if(instance == null)
      {
        instance = new PaymentMethodDAO();
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
   * Adds a new payment method to the database
   *
   * @param paymentMethod the PaymentMethod object to be added.
   * @return the added payment method
   */
  @Override public synchronized PaymentMethod addPaymentMethod(PaymentMethod paymentMethod)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("insert into Payment_Methods(name) values (?);", new String[]{"id"});
      statement.setString(1, paymentMethod.getName());
      statement.executeUpdate();
      ResultSet generatedKeys = statement.getGeneratedKeys();
      if(generatedKeys.next())
      {
        paymentMethod.setId(generatedKeys.getInt("id"));
      }
      else
      {
        throw new RuntimeException("No keys were generated.");
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while adding a payment method to the database: " + e.getMessage());
    }
    return getPaymentMethod(paymentMethod.getId());
  }

  /**
   * Edits an existing payment method in the database
   *
   * @param paymentMethod the PaymentMethod object containing the updated information
   * @return the updated payment method
   */

  @Override public synchronized PaymentMethod editPaymentMethod(PaymentMethod paymentMethod)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("UPDATE Payment_Methods\n"
          + "SET name = ?\n" + "WHERE id = ?;");
      statement.setString(1, paymentMethod.getName());
      statement.setInt(2, paymentMethod.getId());
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while editing a payment method in the database: " + e.getMessage());
    }
    return getPaymentMethod(paymentMethod.getId());
  }

  /**
   * Deletes a payment method from the database
   *
   * @param paymentMethodId the paymentMethod that gets deleted
   */
  @Override public synchronized void deletePaymentMethod(int paymentMethodId)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("DELETE FROM Delivery_Options\n"
          + "WHERE id = ?;");
      statement.setInt(1, paymentMethodId);
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while deleting a payment method from the database: " + e.getMessage());
    }
  }

  /**
   * Retrieves a payment method from the database using its own id
   * @param paymentMethodId the unique ID of the payment method to retrieve.
   * @return the requested payment method
   */
  @Override public PaymentMethod getPaymentMethod(int paymentMethodId)
  {
    PaymentMethod response = null;
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT id, name\n"
          + "FROM Payment_Methods\n" + "WHERE id = ?;");
      statement.setInt(1, paymentMethodId);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        response = new PaymentMethod();
        response.setId(rs.getInt("id"));
        response.setName(rs.getString("name"));
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting a payment method from the database: " + e.getMessage());
    }
    return response;
  }

  /**
   * Retrieves a list with all the payment methods from the database
   * @return a list with all the payment methods from the database
   */
  @Override public ArrayList<PaymentMethod> getAllPaymentMethods()
  {
    ArrayList<PaymentMethod> response = new ArrayList<>();
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT id, name\n"
          + "FROM Payment_Methods;");
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        PaymentMethod element = new PaymentMethod(rs.getInt("id"),rs.getString("name"));
        response.add(element);
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting all payment methods from the database: " + e.getMessage());
    }
    return response;
  }
}
