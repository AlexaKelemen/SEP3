
package ServerGRPC;

import proto.GetUserRequest;
import proto.GetUserResponse;
import proto.UserServiceGrpc;
import io.grpc.stub.StreamObserver;

public class UserServiceImpl extends UserServiceGrpc.UserServiceImplBase
{
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
}

