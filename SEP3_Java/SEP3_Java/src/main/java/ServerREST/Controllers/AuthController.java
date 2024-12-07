package ServerREST.Controllers;

import DataTransferObjects.LoginRequestDTO;
import DataTransferObjects.UserDTO;
import Database.DAOInterface.UserDAOInterface;
import Database.Implementation.UserDAO;
import Entities.User;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.sql.SQLException;
import java.util.ArrayList;

@RestController
public class AuthController
{
  private UserDAOInterface userDAO;
  public AuthController()
  {
    userDAO = UserDAO.getInstance();
  }

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
    if(user.getUsername().isEmpty())
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
