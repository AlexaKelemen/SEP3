package Shared.Database;

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.time.LocalDate;
import java.time.YearMonth;

public class DatabaseFactory
{

  public Connection establishConnection()
  {
    try
    {
      return DriverManager.getConnection("jdbc:postgresql://localhost:5432/postgres?currentSchema=user_domain", "postgres", "fatcat");
        }
    catch (SQLException e)
    {
      System.out.println("Connection failed. Try a different password perhaps.");
      return null;
    }
  }

  public Date convertToSqlCardDate(LocalDate date)
  {
    YearMonth helper = YearMonth.of(date.getYear()-1900, date.getMonthValue());
    Date returnDate = new Date(date.getYear() - 1900, date.getMonthValue()-1, helper.atEndOfMonth().getDayOfMonth());
    return returnDate;
  }

  public Date convertToSqlDate(LocalDate date)
  {
    Date returnDate = new Date(date.getYear() - 1900, date.getMonthValue()-1, date.getDayOfMonth());
    return returnDate;
  }

}
