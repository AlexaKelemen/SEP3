package Shared.Database.Implementation;

import Shared.Database.DAOInterface.CreditDAOInterface;
import Shared.Database.DatabaseFactory;

import javax.swing.plaf.PanelUI;
import java.sql.*;
/**
 * Handles database operations related to user credit.
 */
public class CreditDAO extends DatabaseFactory implements CreditDAOInterface
{
  /** Singleton instance of the CreditDAO class. */
  public static CreditDAO instance;

  /**
   * Private constructor to enforce singleton pattern.
   * Registers the PostgreSQL  driver.
   *
   * @throws SQLException if an error occurs during driver registration.
   */
  private CreditDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }

  /**
   * Returns the singleton instance of the CreditDAO class.
   *
   * @return CreditDAO instance.
   */
  public static synchronized CreditDAO getInstance()
  {
    try
    {
      if(instance == null)
      {
        instance = new CreditDAO();
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
   * Adds credit for a specific user in the database.
   *
   * @param username the username of the user to add credit for.
   * @param credit   the amount of credit to add.
   * @return the updated credit for the user
   */
  @Override public int addCredit(String username, int credit)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("insert into Items_Returned(credit, username) VALUES (?,?);");
      statement.setInt(1, credit);
      statement.setString(2, username);
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while adding credit for a user: " + e.getMessage());
    }
    return getCredit(username);
  }

  /**
   * Edits the credit for a specific user
   *
   * @param username the username of the user whose credit will be edited.
   * @param credit   the new credit value to set.
   * @return the updated credit for the user
   */
  @Override public int editCredit(String username, int credit)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("UPDATE Items_Returned\n"
          + "SET credit = ?\n" + "WHERE username = ?;");
      statement.setInt(1, credit);
      statement.setString(2, username);
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while editing credit for a user: " + e.getMessage());
    }
    return getCredit(username);
  }

  /**
   * deletes credit from a specific user
   * @param username the username of the user whose credit will be deleted.
   */
  @Override public void deleteCredit(String username)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("DELETE FROM Items_Returned\n"
          + "WHERE username = ?;");
      statement.setString(1, username);
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while deleting credit for a user: " + e.getMessage());
    }
  }
  /**
   * Retrieves the current credit value for a specific user from the database.
   *
   * @param username the username of the user.
   * @return the current credit value for the user.
   */
  @Override public int getCredit(String username)
  {
    int credit = -1;
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT credit\n"
          + "FROM Items_Returned\n" + "WHERE username = ?;");
      statement.setString(1, username);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        credit = rs.getInt("credit");
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while adding credit for a user: " + e.getMessage());
    }
    return credit;
  }
}
