package ServerREST.Controllers;

import DataTransferObjects.UserDTO;
import Database.DAOInterface.CardDAOInterface;
import Database.DAOInterface.UserDAOInterface;
import Database.Implementation.CardDAO;
import Database.Implementation.UserDAO;
import Entities.Card;
import Entities.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.sql.SQLException;
import java.util.ArrayList;

@RestController
public class UserController
{
  private UserDAOInterface userDAO;
  private CardDAOInterface cardDAO;
  public UserController()
  {
    userDAO = UserDAO.getInstance();
    cardDAO = CardDAO.getInstance();
  }

  @GetMapping("/users/{username}/{cardIncluded}")
  public ResponseEntity<UserDTO> getUser(@PathVariable(value = "username") String username, @PathVariable(value = "cardIncluded", required = false) boolean cardIncluded)
  {
    User user = userDAO.getUser(username);
    UserDTO response;
    if (user == null)
    {
      //return new UserDTO(new User("", "")).toJson();
      return new ResponseEntity<>(new UserDTO(), HttpStatus.NOT_FOUND);
    }
    response = new UserDTO(user);
    if (cardIncluded)
    {
      ArrayList<Card> cards = cardDAO.getAllCards();
      for (int i = 0; i < cards.size(); i++)
      {
        if(cards.get(i).getUsername().equals(user.getUsername()))
        {
          Card card = cards.get(i);
          response.setCard(card);
        }
      }
    }
    return new ResponseEntity<>(response, HttpStatus.OK);
  }

  @PutMapping("/users/{username}")
  public ResponseEntity<UserDTO> updateUser(@PathVariable(value = "username") String username, @RequestBody User request)
  {
    try
    {
      return new ResponseEntity<>(new UserDTO(userDAO.editUser(request)), HttpStatus.OK) ;
    }
    catch (Exception e)
    {
      System.out.println(e.getMessage());
      return new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }
  }

  //More stuff is needed! Deleting user (should delete all relating cards and orders to them as well), inserting user, getting all users
}
