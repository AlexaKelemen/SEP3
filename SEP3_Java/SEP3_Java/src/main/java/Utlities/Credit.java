package Utlities;

import java.time.LocalDate;


public class Credit
{
  private int amount;
  private LocalDate expirationDate;

  public Credit(int amount, LocalDate expirationDate)
  {
    this.amount = amount;
    this.expirationDate = expirationDate;
  }

  public LocalDate getExpirationDate()
  {
    return expirationDate;
  }

  public int getAmount()
  {
    return amount;
  }

  public void setAmount(int amount)
  {
    this.amount = amount;
  }

  public void setExpirationDate(LocalDate expirationDate)
  {
    this.expirationDate = expirationDate;
  }
}
