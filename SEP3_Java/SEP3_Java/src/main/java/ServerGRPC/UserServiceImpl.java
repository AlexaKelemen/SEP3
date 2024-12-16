
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

public class UserServiceImpl extends UserServiceGrpc.UserServiceImplBase
{
  private ManagerInterface manager = ManagerImpl.getInstance();
  public void getUser(GetUserRequest request,
      StreamObserver<GetUserResponse> responseObserver)
  {
    GetUserResponse response = GetUserResponse.newBuilder()
        .setUsername(request.getUsername()).setEmail("placeholder@gmail.com")
        .setFirstName("Jane").setLastName("Doe")
        .setShippingAddress("some place in the world")
        .setBillingAddress("some place in the world")
        .setPaymentInformation("1234123456785678").build();

    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }

  public void addOrder(GetOrderRequest request, StreamObserver<GetOrderResponse> responseObserver)
  {
    GetOrderResponse response = manager.addOrder(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }

  public void getAllOrdersForUser(GetAllOrdersRequest request, StreamObserver<GetAllOrdersResponse> responseStreamObserver)
  {

  }
}

