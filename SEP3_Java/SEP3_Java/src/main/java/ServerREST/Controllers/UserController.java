package ServerREST.Controllers;

import Shared.DataTransferObject.UserDTO;
import Shared.Database.DAOInterface.CardDAOInterface;
import Shared.Database.DAOInterface.UserDAOInterface;
import Shared.Database.Implementation.CardDAO;
import Shared.Database.Implementation.UserDAO;
import Shared.Entities.Card;
import Shared.Entities.User;
import Shared.ManagerImpl;
import Shared.ManagerInterface;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;

@RestController
public class UserController
{
  private UserDAOInterface userDAO;
  private CardDAOInterface cardDAO;
  ManagerInterface manager;
  public UserController()
  {
    userDAO = UserDAO.getInstance();
    cardDAO = CardDAO.getInstance();
    manager = ManagerImpl.getInstance();
  }

  @GetMapping("/users/{username}/{cardIncluded}")
  public ResponseEntity<UserDTO> getUserWithCard(@PathVariable(value = "username") String username, @PathVariable(value = "cardIncluded", required = false) boolean cardIncluded)
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

  @GetMapping("/users/{username}")
  public ResponseEntity<UserDTO> getUser(@PathVariable(value = "username") String username)
  {
    User user = userDAO.getUser(username);
    UserDTO response;
    if (user == null)
    {
      //return new UserDTO(new User("", "")).toJson();
      return new ResponseEntity<>(new UserDTO(), HttpStatus.NOT_FOUND);
    }
    response = new UserDTO(user);
    return new ResponseEntity<>(response, HttpStatus.OK);
  }

  @PutMapping("/users/{username}")
  public ResponseEntity<UserDTO> updateUser(@PathVariable(value = "username") String username, @RequestBody UserDTO request)
  {
    try
    {
      if(request.getCard() != null)
      {
        if(request.getCard().getCardId() == -1)
        {
          request.setCard(cardDAO.addCard(request.getCard()));
        }
        else
        {
          request.setCard(cardDAO.editCard(request.getCard()));
        }
      }
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
