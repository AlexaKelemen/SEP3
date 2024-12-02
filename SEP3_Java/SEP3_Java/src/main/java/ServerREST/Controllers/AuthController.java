package ServerREST.Controllers;

import DataTransferObjects.UserDTO;
import Database.DAOInterface.UserDAOInterface;
import Database.Implementation.UserDAO;
import Entities.User;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.sql.SQLException;

@RestController
public class AuthController
{
  private UserDAOInterface userDAO;
  public AuthController()
  {
    userDAO = UserDAO.getInstance();
  }

  @PostMapping("auth/login")
  public synchronized ResponseEntity<UserDTO> login(@RequestBody User request)
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
    if(user == null)
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
}
