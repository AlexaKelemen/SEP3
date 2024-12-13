using Entities;

namespace BlazorApp1.Auth;
using System.Security.Claims;
using System.Text.Json;
using DataTransferObjects;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

public class SimpleAuthProvider : AuthenticationStateProvider
{
    private readonly HttpClient httpClient;
    private readonly IJSRuntime jsRuntime;

    public SimpleAuthProvider()
    {
        
    }
    public SimpleAuthProvider(IHttpClientFactory httpClientFactory, IJSRuntime jsRuntime)
    {
        httpClient = httpClientFactory.CreateClient("Users");
        this.jsRuntime = jsRuntime;
    }

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

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string userAsJson = "";
        try
        { 
            userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
        }
        catch (InvalidOperationException exception)
        {
            return new AuthenticationState(new());
        }

        if (string.IsNullOrEmpty(userAsJson))
        {
            return new AuthenticationState(new());
        }

        UserDTO userDto = JsonSerializer.Deserialize<UserDTO>(userAsJson)!;
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, userDto.Username),
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth");ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
        return new AuthenticationState(claimsPrincipal);

    }
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