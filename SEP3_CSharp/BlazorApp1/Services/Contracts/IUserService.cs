namespace BlazorApp1.Services;
using DataTransferObjects;

public interface IUserService
{
    public Task<UserDTO> AddUserAsync(CreateUserDTO request);
    public Task<UserDTO> GetUserAsync(string username);
    public Task<List<UserDTO>> GetUsersAsync();
    public Task EditUserAsync(string username, UserDTO request);

}