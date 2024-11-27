namespace BlazorApp1.Services;
using System.Text.Json;
using DataTransferObjects;
public class HttpUserService:IUserService
{
    private readonly HttpClient _httpClient;

    public HttpUserService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<UserDTO> AddUserAsync(CreateUserDTO request)
    {
        //needs implementing
        return null;
    }
    public async Task<UserDTO> GetUserAsync(int id)
    {
        //needs implementing
        return null;
    }
    public async Task<List<UserDTO>> GetUsersAsync()
    {
        //needs implementing
        return null;
    }

   
}