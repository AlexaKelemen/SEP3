package Shared.Database.DAOInterface;

public interface CreditDAOInterface
{
  /**
   * Adds a specified amount of credit to a user's account.
   *
   * @param username the username of the user to add credit for.
   * @param credit   the amount of credit to add.
   * @return the updated total credit of the user after addition.
   */
  public int addCredit(String username, int credit);

  /**
   * Edits a user's credit by setting it to a new value.
   *
   * @param username the username of the user whose credit will be edited.
   * @param credit   the new credit value to set.
   * @return the updated total credit of the user after the edit.
   */
  public int editCredit(String username, int credit);


  /**
   * Deletes a user's credit record from the database.
   *
   * @param username the username of the user whose credit will be deleted.
   */
  public void deleteCredit(String username);
  /**
   * Retrieves the current credit of a user.
   *
   * @param username the username of the user whose credit is to be retrieved.
   * @return the current credit of the user.
   */
  public int getCredit(String username);
}
