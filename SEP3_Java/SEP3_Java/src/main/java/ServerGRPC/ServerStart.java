package ServerGRPC;

import io.grpc.ServerBuilder;
import io.grpc.Server;

/**
 * Main class for starting the gRPC server.
 */
public class ServerStart
{

  /**
   * The entry point of the application. This method initializes and starts the gRPC server.
   *
   * @param args Command-line arguments passed to the application.
   * @throws Exception if the server fails to start or if it encounters an error during operation.
   */
  public static void main(String[] args) throws Exception
  {
    Server server = ServerBuilder.forPort(8089).addService(new UserServiceImpl()).build();
    server.start();
    server.awaitTermination();
  }
}
