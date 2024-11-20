package DataTransferObjects;

import Entities.User;
import com.fasterxml.jackson.annotation.JsonGetter;
import com.fasterxml.jackson.databind.ObjectMapper;

public class UserDTO
{
  private String username;
  private String email;
  private String firstName;
  private String lastName;
  private String shippingAddress;
  private String billingAddress;
  private static final ObjectMapper mapper = new ObjectMapper();

  public UserDTO(){}
  public UserDTO(User user)
  {
    username = user.getUsername();
    email = user.getEmail();
    firstName = user.getFirstName();
    lastName = user.getLastName();
    shippingAddress = user.getShippingAddress();
    billingAddress = user.getBillingAddress();
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
  public void setShippingAddress(String shippingAddress){this.shippingAddress = shippingAddress;}
  @JsonGetter("shippingaddress")
  public String getShippingAddress(){return shippingAddress;}
  public void setBillingAddress(String billingAddress){this.billingAddress = billingAddress;}
  @JsonGetter("billingaddress")
  public String getBillingAddress(){return billingAddress;}

  public String toJson()
  {
    try
    {
      return mapper.writeValueAsString(this);
    }
    catch (Exception e)
    {
      e.printStackTrace();
      return null;
    }
  }

  public static UserDTO fromJson(String json)
  {
    try
    {
      return mapper.readValue(json, UserDTO.class);
    }
    catch (Exception e)
    {
      e.printStackTrace();
      return null;
    }
  }
}
