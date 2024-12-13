package Shared.Entities.Utlities;

public class DeliveryOption
{
  private int id;
  private String name;
  private String toAddress;

  public DeliveryOption(int id, String name, String toAddress)
  {
    this.id = id;
    this.name = name;
    this.toAddress = toAddress;
  }
}
