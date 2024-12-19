package Shared;

import Shared.Entities.Order;
/**
 * Defines the operations for managing orders and user-related actions.
 * This interface provides methods for handling various order-related functionalities,
 * including adding, retrieving, refunding, and returning orders. It also includes methods
 * for managing user credit.
 */
public interface ManagerInterface
{
  /**
   * Adds a new order based on the provided request.
   *
   * @param order the proto.GetOrderRequest containing order details
   * @return a proto.GetOrderResponse indicating the result of the operation
   */
  public proto.GetOrderResponse addOrder(proto.GetOrderRequest order);
  /**
   * Retrieves all orders associated with a specific user.
   *
   * @param user the proto.GetAllOrdersRequest identifying the user
   * @return a proto.GetAllOrdersResponse containing the list of orders
   */
  public proto.GetAllOrdersResponse getAllOrdersForUser(
      proto.GetAllOrdersRequest user);

  /**
   * Processes a refund for a specific order.
   *
   * @param refund the proto.GetRefundOrderRequest identifying the order to refund
   * @return a proto.GetBooleanResponse indicating whether the refund was successful
   */
  public proto.GetBooleanResponse refundAnOrder(
      proto.GetRefundOrderRequest refund);

  /**
   * Handles the return of a specific order.
   *
   * @param request the proto.GetReturnOrderRequest identifying the order to return
   * @return a proto.GetBooleanResponse indicating whether the return was successful
   */
  public proto.GetBooleanResponse returnAnOrder(
      proto.GetReturnOrderRequest request);

  /**
   * Retrieves the credit information for a specific user.
   *
   * @param request the proto.GetCreditRequest containing user details
   * @return a proto.GetCreditResponse with the user's credit information
   */
  public proto.GetCreditResponse getCreditForUser(proto.GetCreditRequest request);

  /**
   * Sets the credit for a specific user.
   *
   * @param request the proto.SetCreditRequest containing the user's credit details
   * @return a proto.GetBooleanResponse indicating whether the credit update was successful
   */
  public proto.GetBooleanResponse setCreditForUser(
      proto.SetCreditRequest request);
}
