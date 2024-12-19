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

/**
 * RestController for user operations
 */
@RestController
public class UserController
{
  /**
   * DAO for accessing user related data
   */
  private UserDAOInterface userDAO;
  /**
   * DAO for accessing card related data
   */
  private CardDAOInterface cardDAO;
  /**
   * Manager interface for managing user and card information
   */
  ManagerInterface manager;

  /**
   * Constructor for initialising UserController
   */
  public UserController()
  {
    userDAO = UserDAO.getInstance();
    cardDAO = CardDAO.getInstance();
    manager = ManagerImpl.getInstance();
  }

  /**
   *  Retrieves a user by username, optionally including card related information
   *
   * @param username the username of the user
   * @param cardIncluded whether to include card details or not
   *
   * @return a ResponseEntity containing the UserDTO if found, or an error status otherwise.
   */

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
  /**
   * Retrieves a user by username.
   *
   * @param username the username of the user.
   * @return a ResponseEntity containing the UserDTO if found, or an error status otherwise.
   */

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
  /**
   * Updates a user's information by username.
   *
   * @param username the username of the user to update.
   * @param request the UserDTO containing updated user information.
   * @return a ResponseEntity containing the updated UserDTO if successful, or an error status otherwise.
   */

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
