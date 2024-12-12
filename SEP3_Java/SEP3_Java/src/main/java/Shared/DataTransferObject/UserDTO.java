package Shared.DataTransferObject;

import Shared.Entities.Card;
import Shared.Entities.User;
import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonGetter;

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

  public UserDTO(){}
  public UserDTO(User user)
  {
    username = user.getUsername();
    email = user.getEmail();
    firstName = user.getFirstName();
    lastName = user.getLastName();
    billingAddress = user.getBillingAddress();
  }

  public UserDTO(User user, Card card)
  {
    username = user.getUsername();
    email = user.getEmail();
    firstName = user.getFirstName();
    lastName = user.getLastName();
    billingAddress = user.getBillingAddress();
    this.card = card;
  }

  public void setUsername(String username){this.username = username;}

  @JsonGetter("username")
  public String getUsername() {return username;}
  public void setEmail(String email){this.email = email;}
  @JsonGetter("email")
  public String getEmail(){return email;}
  public void setFirstName(String firstName){this.firstName = firstName;}
  @JsonGetter("firstname")
  public String getFirstName(){return firstName;}
  public void setLastName(String lastName){this.lastName = lastName;}
  @JsonGetter("lastname")
  public String getLastName(){return lastName;}
  public void setBillingAddress(String billingAddress){this.billingAddress = billingAddress;}
  @JsonGetter("billingaddress")
  public String getBillingAddress(){return billingAddress;}
  public void setCard(Card card)
  {
    this.card = card;
  }

  @JsonGetter("card")
  public Card getCard(){return card;}

}
