package Shared;

import Shared.Entities.Order;
import proto.GetOrderRequest;
import proto.GetOrderResponse;

public interface ManagerInterface
{
  public GetOrderResponse addOrder(GetOrderRequest order);
}
