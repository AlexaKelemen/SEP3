package Shared.Database.DAOInterface;

import Shared.DataTransferObject.UserDTO;
import Shared.Entities.User;

import java.util.ArrayList;

/**
 * Interface for managing user-related database operations.
 * <p>
 * This interface defines methods for creating, updating, deleting, and retrieving
 * user information in the database, as well as retrieving all users.
 * </p>
 */
public interface UserDAOInterface
{
  /**
   * Adds a new user to the database.
   *
   * @param user the  User object to be added.
   * @return the added  User object
   */
  public User addUser(User user);

  /**
   * Edits an existing user in the database
   *
   * @param user the User object containing the updated information
   * @return the updated User object
   */
  public User editUser(UserDTO user);

  /**
   * Deletes a user from the database
   *
   * @param username the User's username to be deleted
   */
  public void deleteUser(String username);
  /**
   * Retrieves a specific user from the database using their username.
   *
   * @param username the unique username of the user to retrieve.
   * @return the  User object corresponding to the given username, or null if no such user exists.
   */
  public User getUser(String username);

  /**
   * Retrieves all the users from the database
   *
   * @return a list containing all the users
   */
  public ArrayList<User> getAllUsers();

}
