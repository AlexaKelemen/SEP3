package Shared.Database.Implementation;

import Shared.DataTransferObject.UserDTO;
import Shared.Database.DAOInterface.UserDAOInterface;
import Shared.Database.DatabaseFactory;
import Shared.Entities.User;

import java.sql.*;
import java.util.ArrayList;
/**
 * Handles database operations related to Users
 */
public class UserDAO extends DatabaseFactory implements UserDAOInterface
{
  /** Singleton instance of the UserDAO class. */
  private static UserDAO instance;
  /**
   * Private constructor to enforce singleton pattern.
   * Registers the PostgreSQL driver.
   *
   * @throws SQLException if an error occurs during driver registration.
   */
  private UserDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }
  /**
   * Returns the singleton instance of the UserDAO class.
   *
   * @return UserDAO instance.
   */
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

  /**
   * Adds a new user to the database
   *
   * @param user the  User object to be added.
   * @return the added user
   */
  @Override public synchronized User addUser(User user)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("insert into customer(username, password, e_mail, f_name, l_name, billing_address) VALUES (?, ?, ?, ?, ?, ?);");
      statement.setString(1, user.getUsername());
      statement.setString(2, user.getPassword());
      statement.setString(3, user.getEmail());
      statement.setString(4, user.getFirstName());
      statement.setString(5, user.getLastName());
      statement.setString(6, user.getBillingAddress());
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while adding a user to the database: " + e.getMessage());
    }
    return getUser(user.getUsername());
  }

  /**
   * Edits an existing user from the database
   *
   * @param user the User object containing the updated information
   * @return the user with updated information
   */
  @Override public synchronized User editUser(UserDTO user)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("UPDATE customer\n"
          + "SET e_mail = ?, f_name = ?, l_name = ?, billing_address = ?\n"
          + "WHERE username = ?;");
      statement.setString(1, user.getEmail());
      statement.setString(2, user.getFirstName());
      statement.setString(3, user.getLastName());
      statement.setString(4, user.getBillingAddress());
      statement.setString(5, user.getUsername());
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while updating the user in the database: " + e.getMessage());
    }
    return getUser(user.getUsername());
  }

  /**
   * Deletes a user from the database
   *
   * @param username the User's username to be deleted
   */
  @Override public synchronized void deleteUser(String username)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("DELETE FROM customer\n"
          + "WHERE username = ?;");
      statement.setString(1, username);
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong during deleting from the database.");
    }
  }

  /**
   * Retrieves a user from the database using their unique id
   *
   * @param username the unique username of the user to retrieve.
   * @return a requested user using their id
   */
  @Override public User getUser(String username)
  {
    User response = null;
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

  /**
   * Retrieves a list with all the users from the database
   * @return a list with all the users from the database
   */
  @Override public ArrayList<User> getAllUsers()
  {
      ArrayList<User> allUsers = new ArrayList<>();
      try(Connection connection = super.establishConnection())
      {
        PreparedStatement statement = connection.prepareStatement("SELECT username, password, e_mail, f_name, l_name, billing_address\n"
            + "FROM customer");
        ResultSet rs = statement.executeQuery();
        while (rs.next())
        {
          String username = rs.getString("username");
          String password = rs.getString("password");
          String e_mail = rs.getString("e_mail");
          String f_name = rs.getString("f_name");
          String l_name = rs.getString("l_name");
          String billingAddress = rs.getString("billing_address");
          User element = new User(username, password);
          element.setEmail(e_mail);
          element.setFirstName(f_name);
          element.setLastName(l_name);
          element.setBillingAddress(billingAddress);
          allUsers.add(element);
        }
      }
      catch (SQLException e)
      {
        throw new RuntimeException("Something went wrong while fetching all cards: " + e.getMessage());
      }
      return allUsers;
  }
}
