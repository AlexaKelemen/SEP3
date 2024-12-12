package Entities;

import Entities.Utlities.PaymentMethod;

import java.time.LocalDate;
import java.util.ArrayList;

public class Order
{
  private int orderId;
  private LocalDate placedOn;
  private PaymentMethod paymentMethod;
  private double totalAmount;
  private int deliveryOption; //This one may change
  private ArrayList<Item> items;
  private String placedBy;

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
    return placedOn;
  }

  public int getDeliveryOption()
  {
    return deliveryOption;
  }

  public PaymentMethod getPaymentMethod()
  {
    return paymentMethod;
  }

  public void setDeliveryOption(int deliveryOption)
  {
    this.deliveryOption = deliveryOption;
  }
  public void setPaymentMethod(PaymentMethod paymentMethod)
  {
    this.paymentMethod = paymentMethod;
  }

  public void setDate(LocalDate date)
  {
    this.placedOn = date;
  }

}
