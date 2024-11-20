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
    }
    public async Task<UserDTO> GetUserAsync(int id)
    {
    }
    public async Task<List<UserDTO>> GetUsersAsync()
    {
    }

   
}