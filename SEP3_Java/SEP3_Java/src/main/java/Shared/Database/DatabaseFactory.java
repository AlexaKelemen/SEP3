package Shared.Database;

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.time.LocalDate;
import java.time.YearMonth;

/**
 *Factory class for managing database connections
 */
public class DatabaseFactory
{
  /**
   * Establishes a connection to the database.
   * <p>
   * Connects to a PostgreSQL database using the provided connection URL, username, and password.
   * If the connection fails, it returns null and prints an error message.
   * </p>
   *
   * @return a Connection object if the connection is successful, or null if the connection fails.
   */
  public Connection establishConnection()
  {
    try
    {
      return DriverManager.getConnection("jdbc:postgresql://localhost:5432/postgres?currentSchema=user_domain", "postgres", "1234567");
        }
    catch (SQLException e)
    {
      System.out.println("Connection failed. Try a different password perhaps.");
      return null;
    }
  }
  /**
   * Converts a LocalDate object to a SQL-compatible Date object representing the card expiration date.
   * <p>
   * This method adjusts the year and month to SQL-compatible values and ensures the day of the month
   * is the last day of the provided month.
   * </p>
   *
   * @param date the {@link LocalDate} to be converted.
   * @return a Date object compatible with SQL, representing the card expiration date.
   */
  public Date convertToSqlCardDate(LocalDate date)
  {
    YearMonth helper = YearMonth.of(date.getYear()-1900, date.getMonthValue());
    Date returnDate = new Date(date.getYear() - 1900, date.getMonthValue()-1, helper.atEndOfMonth().getDayOfMonth());
    return returnDate;
  }
  /**
   * Converts a LocalDate object to a SQL-compatible  Date object.
   * This method adjusts the year and month to SQL-compatible values while keeping the day of the month intact.
   *
   * @param date the LocalDate object to be converted.
   * @return a Date object compatible with SQL, matching the provided date.
   */
  public Date convertToSqlDate(LocalDate date)
  {
    Date returnDate = new Date(date.getYear() - 1900, date.getMonthValue()-1, date.getDayOfMonth());
    return returnDate;
  }

}
