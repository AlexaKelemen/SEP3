package Server;

import io.grpc.stub.StreamObserver;
import src.main.UserServiceGrpc;

public class UserServiceImpl extends UserServiceGrpc.UserServiceImplBase
{
  public void getUser(src.main.GetUserRequest request,
      StreamObserver<src.main.GetUserResponse> responseObserver)
  {
    src.main.GetUserResponse response = src.main.GetUserResponse.newBuilder()
        .setUsername(request.getUsername()).setEmail("placeholder@gmail.com")
        .setFirstName("Jane").setLastName("Doe")
        .setShippingAddress("some place in the world")
        .setBillingAddress("some place in the world")
        .setPaymentInformation("1234123456785678").build();

    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }
}
