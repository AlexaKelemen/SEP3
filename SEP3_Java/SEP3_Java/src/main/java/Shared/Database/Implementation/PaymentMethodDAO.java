package Shared.Database.Implementation;

import Shared.Database.DAOInterface.PaymentMethodDAOInterface;
import Shared.Database.DatabaseFactory;
import Shared.Entities.Utlities.PaymentMethod;

import java.sql.*;
import java.util.ArrayList;

public class PaymentMethodDAO extends DatabaseFactory implements PaymentMethodDAOInterface
{
  public static PaymentMethodDAO instance;

  private PaymentMethodDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }

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
  @Override public synchronized PaymentMethod addPaymentMethod(PaymentMethod paymentMethod)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("insert into Payment_Methods(name) values (?);");
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
