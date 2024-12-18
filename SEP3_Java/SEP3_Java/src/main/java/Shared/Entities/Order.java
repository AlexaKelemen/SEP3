package Shared.Entities;

import Shared.Entities.Utlities.DeliveryOption;
import Shared.Entities.Utlities.PaymentMethod;

import java.time.LocalDate;
import java.util.ArrayList;

public class Order
{
  private ArrayList<Item> items;
  private double totalAmount;
  private int orderId;
  private LocalDate placedOn;
  private PaymentMethod paymentMethod;
  private DeliveryOption deliveryOption;
  private String placedBy;
  private String toAddress;

  public Order(ArrayList<Item> items, double amount)
  {
    this.items = items;
    totalAmount = amount;
  }

  public Order(ArrayList<Item> items, double amount, int orderId, LocalDate placedOn, PaymentMethod paymentMethod, DeliveryOption deliveryOption, String placedBy, String toAddress)
  {
    this.items = items;
    this.totalAmount = amount;
    this.orderId = orderId;
    this.placedOn = placedOn;
    this.paymentMethod = paymentMethod;
    this.deliveryOption = deliveryOption;
    this.placedBy = placedBy;
    this.toAddress = toAddress;
  }

  public Order(){
    items = new ArrayList<>();
    deliveryOption = new DeliveryOption();
    paymentMethod = new PaymentMethod();
  }

  public ArrayList<Item> getItems()
  {
    return items;
  }
  public void setItems(ArrayList<Item> items)
  {
    this.items = items;
  }

  public double getTotalAmount()
  {
    return totalAmount;
  }

  public void setTotalAmount(double totalAmount)
  {
    this.totalAmount = totalAmount;
  }

  public LocalDate getDate()
  {
    return placedOn;
  }

  public DeliveryOption getDeliveryOption()
  {
    return deliveryOption;
  }

  public PaymentMethod getPaymentMethod()
  {
    return paymentMethod;
  }

  public void setDeliveryOption(DeliveryOption deliveryOption)
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

  public void setPlacedBy(String placedBy)
  {
    this.placedBy = placedBy;
  }

  public String getPlacedBy()
  {
    return placedBy;
  }

  public void setToAddress(String toAddress)
  {
    this.toAddress = toAddress;
  }

  public String getToAddress()
  {
    return toAddress;
  }

  public void setOrderId(int orderId)
  {
    this.orderId = orderId;
  }

  public int getOrderId()
  {
    return orderId;
  }
}
