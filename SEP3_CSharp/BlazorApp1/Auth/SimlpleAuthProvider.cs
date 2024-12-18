using Entities;

namespace BlazorApp1.Auth;
using System.Security.Claims;
using System.Text.Json;
using DataTransferObjects;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

/// <summary>
/// Provides authentication functionality for the application, including login, user creation, and retrieving the current authentication state.
/// </summary>
public class SimpleAuthProvider : AuthenticationStateProvider
{
    private readonly HttpClient httpClient;
    private readonly IJSRuntime jsRuntime;

    /// <summary>
    /// Initializes a new instance of the "SimpleAuthProvider" class.
    /// </summary>
    public SimpleAuthProvider() { }

    /// <summary>
    /// Initializes a new instance of the "SimpleAuthProvider" class.
    /// </summary>
    /// <param name="httpClientFactory">The factory to create an "HttpClient" instance for making HTTP requests.</param>
    /// <param name="jsRuntime">The "IJSRuntime"for interacting with JavaScript runtime.</param>
    public SimpleAuthProvider(IHttpClientFactory httpClientFactory, IJSRuntime jsRuntime)
    {
        httpClient = httpClientFactory.CreateClient("Users");
        this.jsRuntime = jsRuntime;
    }

    /// <summary>
    /// Logs in a user by sending the provided credentials to the authentication API and stores the authentication data.
    /// </summary>
    /// <param name="userName">The username of the user attempting to log in.</param>
    /// <param name="password">The password of the user attempting to log in.</param>
    public async Task Login(string userName, string password)
    {
        HttpResponseMessage response = await httpClient.PostAsJsonAsync("auth/login",
            new LoginRequestDTO()
            {
                Username = userName,
                Password = password
            });
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content + response.StatusCode.ToString());
        }

        UserDTO userDto = JsonSerializer.Deserialize<UserDTO>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        string serialisedData = JsonSerializer.Serialize(userDto);
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, userDto.Username),
        };

        ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    /// <summary>
    /// Retrieves the current authentication state, including user information from sessionStorage.
    /// </summary>
    /// <returns>An "AuthenticationState" representing the user's authentication state, including claims.</returns>
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string userAsJson = "";
        try
        { 
            userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
        }
        catch (InvalidOperationException exception)
        {
            return new AuthenticationState(new ClaimsPrincipal());
        }

        if (string.IsNullOrEmpty(userAsJson))
        {
            return new AuthenticationState(new ClaimsPrincipal());
        }

        UserDTO userDto = JsonSerializer.Deserialize<UserDTO>(userAsJson)!;
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, userDto.Username),
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        return new AuthenticationState(claimsPrincipal);
    }

    /// <summary>
    /// Registers a new user by sending the provided credentials to the authentication API and logs them in immediately after creation.
    /// </summary>
    /// <param name="username">The username of the new user to create.</param>
    /// <param name="password">The password of the new user to create.</param>
    public async Task CreateUser(string username, string password)
    {
        HttpResponseMessage response = await httpClient.PostAsJsonAsync("auth/createUser",
            new LoginRequestDTO()
            {
                Username = username,
                Password = password
            });
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        await Login(username, password);
    }
}
