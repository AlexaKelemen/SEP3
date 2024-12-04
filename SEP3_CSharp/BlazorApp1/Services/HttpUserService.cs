namespace BlazorApp1.Services;
using System.Text.Json;
using DataTransferObjects;
public class HttpUserService:IUserService
{
    private readonly HttpClient httpClient;

    public HttpUserService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<UserDTO> AddUserAsync(CreateUserDTO request)
    {
        HttpResponseMessage response = await httpClient.PostAsJsonAsync("users", request);
        string responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseString);
        }
        return JsonSerializer.Deserialize<UserDTO>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
    public async Task<UserDTO> GetUserAsync(string username, bool includeCard)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"users/{username}/{includeCard}");
        string responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseString);
        }

        return JsonSerializer.Deserialize<UserDTO>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
    public async Task<List<UserDTO>> GetUsersAsync()
    {
        HttpResponseMessage response = await httpClient.GetAsync("users");
        string responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseString);
        }

        return JsonSerializer.Deserialize<List<UserDTO>>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task UpdateUserAsync(UserDTO request)
    {
        HttpResponseMessage response = await httpClient.PutAsJsonAsync($"users/{request.Username}", request);
        string responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseString);
        }
    }

   
}