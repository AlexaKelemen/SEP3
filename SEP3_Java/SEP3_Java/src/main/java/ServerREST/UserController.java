package ServerREST;

import DataTransferObjects.UserDTO;
import Database.DAOInterface.UserDAOInterface;
import Database.Implementation.UserDAO;
import Entities.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
public class UserController
{
  private UserDAOInterface userDAO;
  public UserController()
  {
    userDAO = UserDAO.getInstance();
  }

  @GetMapping("/users/{username}")
  public String getUser(@PathVariable(value = "username") String username)
  {
    User user = userDAO.getUser(username);
    if (user == null)
    {
      return new UserDTO(new User("", "")).toJson();
    }
    return new UserDTO(user).toJson();
  }
}
