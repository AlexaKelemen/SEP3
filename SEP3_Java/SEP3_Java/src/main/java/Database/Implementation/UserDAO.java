package Database.Implementation;

import Database.DAOInterface.UserDAOInterface;
import Database.DatabaseFactory;
import Entities.User;
import org.springframework.stereotype.Service;

import java.sql.DriverManager;
import java.sql.SQLException;
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
    //placeholder
    return user;
  }

  @Override public synchronized User editUser(User user)
  {

    return user;
  }

  @Override public synchronized User deleteUser(String username)
  {
    return new User(username, "placeholder");
  }

  @Override public User getUser(String username)
  {
    return new User("hello", "hi");
  }

  @Override public ArrayList<User> getAllUsers()
  {
    return null;
  }
}
