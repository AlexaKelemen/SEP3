
package ServerGRPC;

import Shared.ManagerImpl;
import Shared.ManagerInterface;
import proto.*;
import io.grpc.stub.StreamObserver;

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
    GetBooleanResponse response = manager.refundAnOrder(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }

  public void returnAnOrder(GetReturnOrderRequest request, StreamObserver<GetBooleanResponse> responseObserver)
  {
    GetBooleanResponse response = manager.returnAnOrder(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }

  public void getCreditForUser(GetCreditRequest request, StreamObserver<GetCreditResponse> responseObserver)
  {
    GetCreditResponse response = manager.getCreditForUser(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }
}

