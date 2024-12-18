package Shared;

import Shared.Entities.Order;

public interface ManagerInterface
{
  public proto.GetOrderResponse addOrder(proto.GetOrderRequest order);
  public proto.GetAllOrdersResponse getAllOrdersForUser(
      proto.GetAllOrdersRequest user);
  public proto.GetBooleanResponse refundAnOrder(
      proto.GetRefundOrderRequest refund);
  public proto.GetBooleanResponse returnAnOrder(
      proto.GetReturnOrderRequest request);
  public proto.GetCreditResponse getCreditForUser(proto.GetCreditRequest request);
  public proto.GetBooleanResponse setCreditForUser(
      proto.SetCreditRequest request);
}
