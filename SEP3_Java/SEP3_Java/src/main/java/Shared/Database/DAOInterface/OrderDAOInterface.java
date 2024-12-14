package Shared.Database.DAOInterface;

import Shared.Entities.Order;

import java.util.ArrayList;

public interface OrderDAOInterface
{
  public Order addOrder(Order order);
  public Order editOrder(Order order);
  public void deleteOrder(int orderId);
  public Order getOrder(int orderId);
  public ArrayList<Order> getAllOrders();
}
