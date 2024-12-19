package Shared.DataTransferObject;

import com.fasterxml.jackson.annotation.JsonGetter;
import com.fasterxml.jackson.databind.ObjectMapper;

/**
 * This class is used to encapsulate login credentials (username and password)
 * for transferring data between client and server in a structured format.
 */
public class LoginRequestDTO
{
  private String username;
  private String password;
  private static final ObjectMapper mapper = new ObjectMapper();
  /**
   * Default constructor for deserialization and manual object creation.
   */
  public LoginRequestDTO(){}
  /**
   * Parameterized constructor for initializing a login request with username and password.
   *
   * @param username the username for login.
   * @param password the password for login.
   */
  public LoginRequestDTO(String username, String password)
  {
    this.username = username;
    this.password = password;
  }

  /**
   * Gets the username.
   *
   * @return the username.
   */

  @JsonGetter("username")
  public String getUsername() {return username;}

  /**
   * Gets the password
   *
   * @return the password
   */
  @JsonGetter("password")
  public String getPassword() {return password;}

  /**
   * Serializes the current object to a JSON string.
   *
   * @return a JSON representation of the current object, or null if serialization fails.
   */
  public String toJson()
  {
    try
    {
      return mapper.writeValueAsString(this);
    }
    catch (Exception e)
    {
      e.printStackTrace();
      return null;
    }
  }
  /**
   * Deserializes a JSON string into a LoginRequestDTO object.
   *
   * @param json the JSON string to deserialize.
   * @return a LoginRequestDTO object, or null if deserialization fails.
   */
  public static LoginRequestDTO fromJson(String json)
  {
    try
    {
      return mapper.readValue(json, LoginRequestDTO.class);
    }
    catch (Exception e)
    {
      e.printStackTrace();
      return null;
    }
  }
}
