
package ServerGRPC;

import Shared.ManagerImpl;
import Shared.ManagerInterface;
import io.grpc.stub.StreamObserver;

public class UserServiceImpl extends proto.UserServiceGrpc.UserServiceImplBase
{
  private ManagerInterface manager = ManagerImpl.getInstance();


  public void addOrder(proto.GetOrderRequest request, StreamObserver<proto.GetOrderResponse> responseObserver)
  {
    proto.GetOrderResponse response = manager.addOrder(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }

  public void getAllOrdersForUser(proto.GetAllOrdersRequest request, StreamObserver<proto.GetAllOrdersResponse> responseObserver)
  {
    proto.GetAllOrdersResponse response = manager.getAllOrdersForUser(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }

  public void refundAnOrder(proto.GetRefundOrderRequest request, StreamObserver<proto.GetBooleanResponse> responseObserver)
  {
    proto.GetBooleanResponse response = manager.refundAnOrder(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }

  public void returnAnOrder(proto.GetReturnOrderRequest request, StreamObserver<proto.GetBooleanResponse> responseObserver)
  {
    proto.GetBooleanResponse response = manager.returnAnOrder(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }

  public void getCreditForUser(proto.GetCreditRequest request, StreamObserver<proto.GetCreditResponse> responseObserver)
  {
    proto.GetCreditResponse response = manager.getCreditForUser(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }

  public void setCreditForUser(proto.SetCreditRequest request, StreamObserver<proto.GetBooleanResponse> responseObserver)
  {
    proto.GetBooleanResponse response = manager.setCreditForUser(request);
    responseObserver.onNext(response);
    responseObserver.onCompleted();
  }
}

