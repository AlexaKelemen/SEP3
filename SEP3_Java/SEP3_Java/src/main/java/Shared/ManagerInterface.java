package Shared;

import Shared.Entities.Order;
import proto.*;

public interface ManagerInterface
{
  public GetOrderResponse addOrder(GetOrderRequest order);
  public GetAllOrdersResponse getAllOrdersForUser(GetAllOrdersRequest user);
  public GetBooleanResponse refundAnOrder(GetRefundOrderRequest refund);
  public GetBooleanResponse returnAnOrder(GetReturnOrderRequest request);
}
