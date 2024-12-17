package Shared;

import Shared.Entities.Order;
import proto.GetOrderRequest;
import proto.GetOrderResponse;
import proto.GetAllOrdersResponse;
import proto.GetAllOrdersRequest;
import proto.GetBooleanResponse;
import proto.GetRefundOrderRequest;

public interface ManagerInterface
{
  public GetOrderResponse addOrder(GetOrderRequest order);
  public GetAllOrdersResponse getAllOrdersForUser(GetAllOrdersRequest user);
  public GetBooleanResponse refundAnOrder(GetRefundOrderRequest refund);
}
