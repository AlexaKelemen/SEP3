package Database;

import Database.DAOInterface.UserDAOInterface;
import Database.Implementation.UserDAO;
import org.springframework.stereotype.Service;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DatabaseFactory
{

  public Connection establishConnection()
  {
    try
    {
      return DriverManager.getConnection("jdbc:postgresql://localhost:5432/postgres?currentSchema=user_domain", "postgres", "1234567");
        }
    catch (SQLException e)
    {
      System.out.println("Connection failed. Try a different password perhaps.");
      return null;
    }
  }

}
