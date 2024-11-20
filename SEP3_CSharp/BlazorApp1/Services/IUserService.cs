﻿namespace BlazorApp1.Services;
using DataTransferObjects;

public interface IUserService
{
    public Task<UserDTO> AddUserAsync(CreateUserDTO request);
    public Task<UserDTO> GetUserAsync(int id);
    public Task<List<UserDTO>> GetUsersAsync();
    
}