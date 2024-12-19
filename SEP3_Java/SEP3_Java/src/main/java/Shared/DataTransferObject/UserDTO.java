package Shared.DataTransferObject;

import Shared.Entities.Card;
import Shared.Entities.User;
import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonGetter;
/**
 * Data Transfer Object (DTO) for user-related data.
 * This class is used to transfer user data between layers of the application or between client and server.
 * It includes fields for user information and an optional {@link Card} object for billing details.
 *
 */
public class UserDTO
{
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String username;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String email;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String firstName;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String lastName;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String billingAddress;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private Card card;


  /**
   * Default constructor for deserialization and manual object creation.
   */
  public UserDTO(){}

  /**
   * Constructs a UserDTO from a User entity.
   *
   * @param user the User object to populate the DTO.
   */
  public UserDTO(User user)
  {
    username = user.getUsername();
    email = user.getEmail();
    firstName = user.getFirstName();
    lastName = user.getLastName();
    billingAddress = user.getBillingAddress();
  }
  /**
   * Constructs a UserDTO from a User entity and a Card.
   *
   * @param user the  User object to populate the DTO.
   * @param card the Card object to include in the DTO.
   */
  public UserDTO(User user, Card card)
  {
    username = user.getUsername();
    email = user.getEmail();
    firstName = user.getFirstName();
    lastName = user.getLastName();
    billingAddress = user.getBillingAddress();
    this.card = card;
  }
  /**
   * Sets the username.
   *
   * @param username the username to set.
   */
  public void setUsername(String username){this.username = username;}

  /**
   * get the username
   * @return the username
   */
  @JsonGetter("username")
  public String getUsername() {return username;}

  /**
   * sets the email
   * @param email the email to set
   */
  public void setEmail(String email){this.email = email;}

  /**
   * get the email
   * @return the email
   */
  @JsonGetter("email")
  public String getEmail(){return email;}

  /**
   * sets the first name
   * @param firstName the first name to be set
   */
  public void setFirstName(String firstName){this.firstName = firstName;}

  /**
   * gets the first name
   * @return the first name
   */
  @JsonGetter("firstname")
  public String getFirstName(){return firstName;}

  /**
   * sets the last name
   * @param lastName the last name to be set
   */
  public void setLastName(String lastName){this.lastName = lastName;}

  /**
   * gets the last name
   * @return the last name
   */
  @JsonGetter("lastname")
  public String getLastName(){return lastName;}

  /**
   * sets the billing address
   * @param billingAddress the billing address to be set
   */
  public void setBillingAddress(String billingAddress){this.billingAddress = billingAddress;}

  /**
   * gets the billing address
   * @return the billing address
   */
  @JsonGetter("billingaddress")
  public String getBillingAddress(){return billingAddress;}

  /**
   * sets the card
   * @param card the card to be set
   */
  public void setCard(Card card)
  {
    this.card = card;
  }

  /**
   * get the card
   * @return the card
   */

  @JsonGetter("card")
  public Card getCard(){return card;}

}
