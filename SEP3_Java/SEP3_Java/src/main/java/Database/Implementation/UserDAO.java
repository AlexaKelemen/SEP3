package Database.Implementation;

import Database.DAOInterface.UserDAOInterface;
import Database.DatabaseFactory;
import Entities.User;

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
  @Override public User addUser(User user)
  {
    //placeholder
    return user;
  }

  @Override public User editUser(User user)
  {

    return user;
  }

  @Override public User deleteUser(String username)
  {
    return new User(username, "placeholder");
  }

  @Override public User getUser(String username)
  {
    return null;
  }

  @Override public ArrayList<User> getAllUsers()
  {
    return null;
  }
}
