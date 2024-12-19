
package ServerGRPC;

import Shared.ManagerImpl;
import Shared.ManagerInterface;
import io.grpc.stub.StreamObserver;
/**
 * UserServiceImpl is the gRPC service implementation for user operations.
 */
public class UserServiceImpl extends proto.UserServiceGrpc.UserServiceImplBase
{
  /**
   * Manager interface to handle the business logic for user operations.
   */
  private ManagerInterface manager = ManagerImpl.getInstance();

  /**
   * Adds an order for a user.
   *
   * @param request the request containing order details.
   * @param responseObserver the stream observer for the response.
   */
  public void addOrder(proto.GetOrderRequest request, StreamObserver<proto.GetOrderResponse> responseObserver)
  {
    proto.GetOrderResponse response = manager.addOrder(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }
  /**
   * Retrieves all orders for a specific user.
   *
   * @param request the request containing user information.
   * @param responseObserver the stream observer for the response.
   */
  public void getAllOrdersForUser(proto.GetAllOrdersRequest request, StreamObserver<proto.GetAllOrdersResponse> responseObserver)
  {
    proto.GetAllOrdersResponse response = manager.getAllOrdersForUser(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }
  /**
   * Processes a refund for a specific order.
   *
   * @param request the request containing order details to refund.
   * @param responseObserver the stream observer for the response.
   */

  public void refundAnOrder(proto.GetRefundOrderRequest request, StreamObserver<proto.GetBooleanResponse> responseObserver)
  {
    proto.GetBooleanResponse response = manager.refundAnOrder(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }
  /**
   * Processes a return for a specific order.
   *
   * @param request the request containing order details to return.
   * @param responseObserver the stream observer for the response.
   */

  public void returnAnOrder(proto.GetReturnOrderRequest request, StreamObserver<proto.GetBooleanResponse> responseObserver)
  {
    proto.GetBooleanResponse response = manager.returnAnOrder(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }
  /**
   * Retrieves the credit balance for a specific user.
   *
   * @param request the request containing user information.
   * @param responseObserver the stream observer for the response.
   */

  public void getCreditForUser(proto.GetCreditRequest request, StreamObserver<proto.GetCreditResponse> responseObserver)
  {
    proto.GetCreditResponse response = manager.getCreditForUser(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }

  /**
   * Sets the credit balance for a specific user
   *
   * @param request the request containing user and credit details
   * @param responseObserver  the stream observer for the response
   */
  public void setCreditForUser(proto.SetCreditRequest request, StreamObserver<proto.GetBooleanResponse> responseObserver)
  {
    proto.GetBooleanResponse response = manager.setCreditForUser(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }
}

