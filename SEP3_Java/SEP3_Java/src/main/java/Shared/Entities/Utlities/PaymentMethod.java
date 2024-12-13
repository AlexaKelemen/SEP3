package Shared.Entities.Utlities;

public class PaymentMethod
{
  private int id;
  private String name;

  public PaymentMethod(){}

  public PaymentMethod(int id, String name)
  {
    this.id = id;
    this.name = name;
  }

  public void setId(int id) {this.id = id;}
  public int getId() {return id;}
  public void setName(String name) {this.name = name;}
  public String getName() {return name;}
}
