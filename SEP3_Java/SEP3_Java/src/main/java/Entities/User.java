package Entities;

import Utlities.Credit;


public class User
{
  private String username;
  private String password;
  private String email;
  private String firstName;
  private String lastName;
  private String shippingAddress;
  private String billingAddress;

  public User(String username, String password)
  {
    this.username = username;
    this.password = password;
  }

  public void setUsername(String username){this.username = username;}

  public String getUsername() {return username;}
  public String getPassword(){return password;}
  public void setEmail(String email){this.email = email;}
  public String getEmail(){return email;}
  public void setFirstName(String firstName){this.firstName = firstName;}
  public String getFirstName(){return firstName;}
  public void setLastName(String lastName){this.lastName = lastName;}
  public String getLastName(){return lastName;}
  public void setShippingAddress(String shippingAddress){this.shippingAddress = shippingAddress;}

  public String getShippingAddress(){return shippingAddress;}
  public void setBillingAddress(String billingAddress){this.billingAddress = billingAddress;}
  public String getBillingAddress(){return billingAddress;}



}
