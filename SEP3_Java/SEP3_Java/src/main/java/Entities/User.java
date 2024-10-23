package Entities;

import Utlities.Credit;

import java.util.ArrayList;

public class User
{
  private String username;
  private String password;
  private String email;
  private String firstName;
  private String lastName;
  private String shippingAddress;
  private String billingAddress;
  private String paymentInformation;
  private ArrayList<Order> orders;
  private Credit credit;

  public User(String username, String password)
  {
    this.username = username;
    this.password = password;
  }

}
