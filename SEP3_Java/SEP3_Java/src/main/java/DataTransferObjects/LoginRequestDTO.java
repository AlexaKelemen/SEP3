package DataTransferObjects;

import com.fasterxml.jackson.annotation.JsonGetter;
import com.fasterxml.jackson.databind.ObjectMapper;

public class LoginRequestDTO
{
  private String username;
  private String password;
  private static final ObjectMapper mapper = new ObjectMapper();

  public LoginRequestDTO(String username, String password)
  {
    this.username = username;
    this.password = password;
  }

  @JsonGetter("username")
  public String getUsername() {return username;}

  @JsonGetter("password")
  public String getPassword() {return password;}

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
