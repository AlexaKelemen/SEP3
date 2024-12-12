package ServerGRPC;

import io.grpc.ServerBuilder;
import io.grpc.Server;

public class ServerStart
{
  public static void main(String[] args) throws Exception
  {
    Server server = ServerBuilder.forPort(8089).addService(new UserServiceImpl()).build();

    server.start();
    server.awaitTermination();
  }
}
