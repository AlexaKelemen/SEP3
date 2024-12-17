
package ServerGRPC;

import Shared.ManagerImpl;
import Shared.ManagerInterface;
import proto.GetUserRequest;
import proto.GetUserResponse;
import proto.UserServiceGrpc;
import proto.GetOrderRequest;
import proto.GetOrderResponse;
import proto.GetAllOrdersRequest;
import proto.GetAllOrdersResponse;
import io.grpc.stub.StreamObserver;
import proto.GetRefundOrderRequest;
import proto.GetBooleanResponse;

public class UserServiceImpl extends UserServiceGrpc.UserServiceImplBase
{
  private ManagerInterface manager = ManagerImpl.getInstance();


  public void addOrder(GetOrderRequest request, StreamObserver<GetOrderResponse> responseObserver)
  {
    GetOrderResponse response = manager.addOrder(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }

  public void getAllOrdersForUser(GetAllOrdersRequest request, StreamObserver<GetAllOrdersResponse> responseObserver)
  {
    GetAllOrdersResponse response = manager.getAllOrdersForUser(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }

  public void refundAnOrder(GetRefundOrderRequest request, StreamObserver<GetBooleanResponse> responseObserver)
  {

  }
}

