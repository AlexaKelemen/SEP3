namespace BlazorApp1.Services;
using System.Text.Json;
using DataTransferObjects;

/// <summary>
/// A service that handles HTTP requests for managing user data. 
/// Provides methods to add a user, retrieve user details, and update user information.
/// </summary>
public class HttpUserService : IUserService
{
    private readonly HttpClient httpClient;

    /// <summary>
    /// Initializes a new instance of the "HttpUserService" class.
    /// </summary>
    /// <param name="httpClientFactory">Factory for creating HTTP client instances.</param>
    public HttpUserService(IHttpClientFactory httpClientFactory)
    {
        this.httpClient = httpClientFactory.CreateClient("Users");
    }

    /// <summary>
    /// Adds a new user by sending a request to the backend API.
    /// </summary>
    /// <param name="request">The user information to be added.</param>
    /// <returns>The added user details.</returns>
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

    /// <summary>
    /// Retrieves a user by their username from the backend API.
    /// </summary>
    /// <param name="username">The unique identifier (username) of the user to retrieve.</param>
    /// <param name="includeCard">Indicates whether to include the user's card information.</param>
    /// <returns>The requested user details.</returns>
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

    /// <summary>
    /// Retrieves a list of all users from the backend API.
    /// </summary>
    /// <returns>A list of all users.</returns>
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

    /// <summary>
    /// Updates an existing user's details in the backend API.
    /// </summary>
    /// <param name="request">The updated user information.</param>
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
