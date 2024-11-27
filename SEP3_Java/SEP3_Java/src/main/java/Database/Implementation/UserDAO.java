package Database.Implementation;

import DataTransferObjects.UserDTO;
import Database.DAOInterface.UserDAOInterface;
import Database.DatabaseFactory;
import Entities.User;
import org.springframework.stereotype.Service;

import java.sql.*;
import java.util.ArrayList;

public class UserDAO extends DatabaseFactory implements UserDAOInterface
{
  private static UserDAO instance;
  private UserDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }

  public synchronized static UserDAO getInstance()
  {
    try
    {
      if(instance == null)
      {
        instance = new UserDAO();
      }
      return instance;
    }
    catch (SQLException e)
    {
      e.printStackTrace();
      return null;
    }
  }
  @Override public synchronized User addUser(User user)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("insert into customer(username, password, e_mail, f_name, l_name, billing_address) VALUES (?, ?, ?, 'Emily', 'Hansen', 'Horsens, 8700, Marsalle 12, 1st');");
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while adding a user to the database: " + e.getMessage());
    }
    return user;
  }

  @Override public synchronized User editUser(User user)
  {

    return user;
  }

  @Override public synchronized void deleteUser(String username)
  {
    try(Connection connection = super.establishConnection())
    {

    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong during deleting from the database.");
    }
  }

  @Override public User getUser(String username)
  {
    User response = new User("", "");
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT username, password, e_mail, f_name, l_name, billing_address\n"
          + "FROM customer\n" + "WHERE username = ?;");
      statement.setString(1, username);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        username = rs.getString("username");
        String password = rs.getString("password");
        String e_mail = rs.getString("e_mail");
        String f_name = rs.getString("f_name");
        String l_name = rs.getString("l_name");
        String billingAddress = rs.getString("billing_address");
        response = new User(username, password);
        response.setEmail(e_mail);
        response.setFirstName(f_name);
        response.setLastName(l_name);
        response.setBillingAddress(billingAddress);
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong during getting a user in the database: " + e.getMessage());
    }
    return response;
  }

  @Override public ArrayList<User> getAllUsers()
  {
    return null;
  }
}
