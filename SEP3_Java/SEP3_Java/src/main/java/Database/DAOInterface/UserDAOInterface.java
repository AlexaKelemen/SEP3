package Database.DAOInterface;

import Entities.User;

import java.util.ArrayList;

public interface UserDAOInterface
{
  public User addUser(User user);
  public User editUser(User user);
  public User deleteUser(String username);
  public User getUser(String username);
  public ArrayList<User> getAllUsers();

}
