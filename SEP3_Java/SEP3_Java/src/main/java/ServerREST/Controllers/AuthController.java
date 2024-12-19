package ServerREST.Controllers;

import Shared.DataTransferObject.LoginRequestDTO;
import Shared.DataTransferObject.UserDTO;
import Shared.Database.DAOInterface.UserDAOInterface;
import Shared.Database.Implementation.UserDAO;
import Shared.Entities.User;
import Shared.ManagerImpl;
import Shared.ManagerInterface;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.ArrayList;
/**
 * REST controller for authentication operations.
 */
@RestController
public class AuthController
{
  /**
   * DAO for accessing user-related data.
   */
  private UserDAOInterface userDAO;
  /**
   * Manager interface for managing user operations.
   */
  private ManagerInterface manager;

  /**
   * Constructor for initializing AuthController
   */
  public AuthController()
  {
    userDAO = UserDAO.getInstance();
    manager = ManagerImpl.getInstance();
  }

  /**
   * Handles user login.
   *
   *  @param request the login request containing username and password.
   *  @return a ResponseEntity containing the UserDTO if successful, or an error status in case it happens otherwise
   */
  @PostMapping("auth/login")
  public synchronized ResponseEntity<UserDTO> login(@RequestBody LoginRequestDTO request)
  {
    User user;
    try
    {
      user = userDAO.getUser(request.getUsername());
    }
    catch (Exception e)
    {
      System.out.println(e.getMessage());
      return new ResponseEntity<>(HttpStatus.UNAUTHORIZED);
    }
    if(user == null || user.getUsername().isEmpty())
    {
      return new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }
    if(!user.getPassword().equals(request.getPassword()))
    {
      return new ResponseEntity<>(HttpStatus.UNAUTHORIZED);
    }
    UserDTO response = new UserDTO(user);
    return new ResponseEntity<>(response, HttpStatus.OK);
  }

  /**
   * Handles user creation
   *
   * @param request the user details for the new user
   * @return  a ResponseEntity containing the userDTO if successful, or an error status in case it happens otherwise
   */

  @PostMapping("auth/createUser")
  public synchronized ResponseEntity<UserDTO> createUser(@RequestBody User request)
  {
    if(request == null || request.getUsername().isEmpty() || request.getPassword().isEmpty())
    {
      return new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }
    ArrayList<User> users = userDAO.getAllUsers();
    for (int i = 0; i < users.size(); i++)
    {
      if(users.get(i).getUsername().equals(request.getUsername()))
      {
        return new ResponseEntity<>(HttpStatus.UNAUTHORIZED);
      }
    }
    try
    {
      return new ResponseEntity<>(new UserDTO(userDAO.addUser(request)), HttpStatus.CREATED);
    }
    catch (Exception e)
    {
      return new ResponseEntity<>(HttpStatus.UNAUTHORIZED);
    }
  }
}
