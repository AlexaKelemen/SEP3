package Server;

import io.grpc.ServerBuilder;
import io.grpc.Server;

public class ServerStart
{
  public static void main(String[] args) throws Exception
  {
    Server server = ServerBuilder.forPort(8080).addService(new UserServiceImpl()).build();

    server.start();
    server.awaitTermination();
  }
}
