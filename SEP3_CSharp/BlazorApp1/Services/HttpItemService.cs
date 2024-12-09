using System.Text.Json;
using BlazorApp1.Components.Pages;
using BlazorApp1.Services.Contracts;
using DatabaseConnection;
using DataTransferObjects;
using Entities;
using Microsoft.EntityFrameworkCore;
using Proto;

namespace BlazorApp1.Services;

public class HttpItemService : IItemService
{
    private readonly AppDbContext _appDbContext;
    private readonly HttpClient _httpClient;

    public HttpItemService(AppDbContext appDbContext,  HttpClient httpClient)
    {
        _appDbContext = appDbContext;
        this._httpClient = httpClient;
    }

    public async Task<IEnumerable<ItemDTOs>> GetItems()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("items");
            string responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(responseString);
            }

            return JsonSerializer.Deserialize<List<ItemDTOs>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }

    public async Task<ItemDTOs> GetItem(int id)
    {
            HttpResponseMessage response = await _httpClient.GetAsync($"items/{id}");
            string responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(responseString);
            }

            return JsonSerializer.Deserialize<ItemDTOs>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }
}