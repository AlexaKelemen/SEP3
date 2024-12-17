package Shared.Database.Implementation;

import Shared.Database.DAOInterface.CreditDAOInterface;
import Shared.Database.DatabaseFactory;

import javax.swing.plaf.PanelUI;
import java.sql.*;

public class CreditDAO extends DatabaseFactory implements CreditDAOInterface
{
  public static CreditDAO instance;

  private CreditDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }

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
