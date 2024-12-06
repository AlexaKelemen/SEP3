package Database.DAOInterface;

import DataTransferObjects.UserDTO;
import Entities.User;

import java.util.ArrayList;

public interface UserDAOInterface
{
  public User addUser(User user);
  public User editUser(UserDTO user);
  public void deleteUser(String username);
  public User getUser(String username);
  public ArrayList<User> getAllUsers();

}
