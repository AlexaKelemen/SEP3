using System.Text.Json;
using BlazorApp1.Services.Contracts;
using DataTransferObjects;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services;

public class HttpCategoryService: ICategoryService
{
    private readonly HttpClient httpClient;

    public HttpCategoryService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient("Products");
    }
    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        HttpResponseMessage response = await httpClient.GetAsync($"Category/categories");
        string responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseString + " " + response.StatusCode);
        }

        return JsonSerializer.Deserialize<List<Category>>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task<Category> GetCategory(int id)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"categories/{id}");
        string responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseString);
        }

        return JsonSerializer.Deserialize<Category>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
}