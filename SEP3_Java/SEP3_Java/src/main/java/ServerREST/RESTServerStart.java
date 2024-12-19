package ServerREST;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
/**
 * Main class to launch the REST server using Spring Boot.
 */
@SpringBootApplication
public class RESTServerStart
{
  /**
   * The main method to start the Spring Boot application.
   *
   * @param args command-line arguments passed to the application.
   */
  public static void main(String[] args)
  {
    SpringApplication.run(RESTServerStart.class, args);
  }
}
