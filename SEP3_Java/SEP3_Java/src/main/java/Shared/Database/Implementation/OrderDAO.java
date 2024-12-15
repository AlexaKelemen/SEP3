package Shared.Database.Implementation;

import Shared.Database.DAOInterface.OrderDAOInterface;
import Shared.Database.DatabaseFactory;
import Shared.Entities.Order;

import java.math.BigDecimal;
import java.sql.*;
import java.time.LocalDate;
import java.time.YearMonth;
import java.util.ArrayList;
import java.util.ConcurrentModificationException;

public class OrderDAO extends DatabaseFactory implements OrderDAOInterface
{
  public static OrderDAO instance;

  private OrderDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }

  public static synchronized OrderDAO getInstance()
  {
    try
    {
      if(instance == null)
      {
        instance = new OrderDAO();
      }
      return instance;
    }
    catch (SQLException e)
    {
      e.printStackTrace();
      return null;
    }
  }

  @Override public synchronized Order addOrder(Order order)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("insert into Customer_Order(price, placed_on, payment_method, delivery_option, placed_by, to_address) VALUES (?,?,?,?,?,?);");
      statement.setBigDecimal(1, new BigDecimal(order.getTotalAmount()));
      statement.setDate(2, convertToSqlDate(order.getDate()));
      statement.setInt(3, order.getPaymentMethod().getId());
      statement.setInt(4, order.getDeliveryOption().getId());
      statement.setString(5, order.getPlacedBy());
      statement.setString(6, order.getToAddress());
      statement.executeUpdate();
      ResultSet generatedKeys = statement.getGeneratedKeys();
      if(generatedKeys.next())
      {
        order.setOrderId(generatedKeys.getInt("order_id"));
      }
      else
      {
        throw new RuntimeException("No keys were generated.");
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while saving an order in the database: " + e.getMessage());
    }
    return getOrder(order.getOrderId());
  }

  @Override public synchronized Order editOrder(Order order)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("UPDATE Customer_Order\n"
          + "SET price = ?\n" + "WHERE order_id = ?;");
      statement.setBigDecimal(1, new BigDecimal(order.getTotalAmount()));
      statement.setInt(2, order.getOrderId());
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while editing an order in the database: " + e.getMessage());
    }
    return getOrder(order.getOrderId());
  }

  @Override public synchronized void deleteOrder(int orderId)
  {
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("DELETE FROM Customer_Order\n"
          + "WHERE order_id = ?;");
      statement.setInt(1, orderId);
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while deleting an order from the database: " + e.getMessage());
    }
  }

  @Override public Order getOrder(int orderId)
  {
    Order response = new Order();
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT price, placed_on, payment_method, delivery_option, order_id, placed_by, to_address\n"
          + "FROM Customer_Order\n" + "WHERE order_id = ?;");
      statement.setInt(1, orderId);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        response.setTotalAmount(rs.getBigDecimal("price").doubleValue());
        response.setDate(rs.getDate("placed_on").toLocalDate());
        response.getPaymentMethod().setId(rs.getInt("payment_method"));
        response.getDeliveryOption().setId(rs.getInt("delivery_option"));
        response.setOrderId(rs.getInt("order_id"));
        response.setPlacedBy(rs.getString("placed_by"));
        response.setToAddress(rs.getString("to_address"));
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting an order from the database: " + e.getMessage());
    }
    return response;
  }

  @Override public ArrayList<Order> getAllOrders()
  {
    ArrayList<Order> response = new ArrayList<>();
    try(Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT price, placed_on, payment_method, delivery_option, order_id, placed_by, to_address\n"
          + "FROM Customer_Order;");
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        Order element = new Order();
        element.setTotalAmount(rs.getBigDecimal("price").doubleValue());
        element.setDate(rs.getDate("placed_on").toLocalDate());
        element.getPaymentMethod().setId(rs.getInt("payment_method"));
        element.getDeliveryOption().setId(rs.getInt("delivery_option"));
        element.setOrderId(rs.getInt("order_id"));
        element.setPlacedBy(rs.getString("placed_by"));
        element.setToAddress(rs.getString("to_address"));
        response.add(element);
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting all orders from the database: " + e.getMessage());
    }
    return response;
  }

}
