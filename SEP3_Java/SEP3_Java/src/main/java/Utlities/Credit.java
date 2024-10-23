package Utlities;

import java.time.LocalDate;
import java.util.Date;

public class Credit
{
  private int amount;
  private Date expirationDate;

  public Credit(int amount, Date expirationDate)
  {
    this.amount = amount;
    this.expirationDate = expirationDate;
  }

  public Date getExpirationDate()
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

  public void setExpirationDate(Date expirationDate)
  {
    this.expirationDate = expirationDate;
  }
}
