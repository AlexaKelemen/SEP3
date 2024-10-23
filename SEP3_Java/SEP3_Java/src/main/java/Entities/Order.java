package Entities;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Date;

public class Order
{
  private LocalDate date;
  private String paymentMethod;
  private double totalAmount;
  private String deliveryOption;
  private ArrayList<Item> items;

  public Order(ArrayList<Item> items, double amount)
  {
    this.items = items;
    totalAmount = amount;
    date = java.time.LocalDate.now();
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

  public String getDeliveryOption()
  {
    return deliveryOption;
  }

  public String getPaymentMethod()
  {
    return paymentMethod;
  }

  public void setDeliveryOption(String deliveryOption)
  {
    this.deliveryOption = deliveryOption;
  }
  public void setPaymentMethod(String paymentMethod)
  {
    this.paymentMethod = paymentMethod;
  }

}
