package Shared;

import Shared.Entities.Order;
import proto.GetOrderRequest;

public interface ManagerInterface
{
  public boolean addOrder(GetOrderRequest order);
}
