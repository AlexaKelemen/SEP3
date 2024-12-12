package Entities;

import java.time.LocalDate;
import java.util.ArrayList;

public class Order
{
  private LocalDate date;
  private int paymentMethod;
  private double totalAmount;
  private int deliveryOption;
  private ArrayList<Item> items;

  public Order(ArrayList<Item> items, double amount)
  {
    this.items = items;
    totalAmount = amount;
  }

  public ArrayList<Item> getItems()
  {
    return items;
  }

  public double getTotalAmount()
  {
    return totalAmount;
  }

  public LocalDate getDate()
  {
    return date;
  }

  public int getDeliveryOption()
  {
    return deliveryOption;
  }

  public int getPaymentMethod()
  {
    return paymentMethod;
  }

  public void setDeliveryOption(int deliveryOption)
  {
    this.deliveryOption = deliveryOption;
  }
  public void setPaymentMethod(int paymentMethod)
  {
    this.paymentMethod = paymentMethod;
  }

  public void setDate(LocalDate date)
  {
    this.date = date;
  }

}
