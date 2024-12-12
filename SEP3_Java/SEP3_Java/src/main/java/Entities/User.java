package Entities;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonGetter;

public class User
{
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String username;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String password;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String email;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String firstName;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String lastName;
  @JsonFormat(with = JsonFormat.Feature.ACCEPT_CASE_INSENSITIVE_PROPERTIES)
  private String billingAddress;


  public User(){}
  public User(String username, String password)
  {
    this.username = username;
    this.password = password;
  }

  public void setUsername(String username){this.username = username;}

  @JsonGetter("username")
  public String getUsername() {return username;}
  @JsonGetter("password")
  public String getPassword(){return password;}
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

}
