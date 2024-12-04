﻿using System.Text;
using BlazorApp1.Services.Contracts;
using DataTransferObjects;

namespace BlazorApp1.Services;

public class HttpCartService : ICartService

{
    private readonly HttpClient httpClient;
    public event Action<int> OnShoppingCartChanged;

    public HttpCartService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<CartItemDTO?> AddItem(CartItemToAddDTO cartItemToAddDto)
    {
        var response =
            await httpClient.PostAsJsonAsync<CartItemToAddDTO>(
                "api/ShoppingCart", cartItemToAddDto);

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default(CartItemDTO);
            }

            return await response.Content.ReadFromJsonAsync<CartItemDTO>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(
            $"Http status:{response.StatusCode} Message -{message}");
    }

    public async Task<CartItemDTO?> DeleteItem(int id)
    {
        try
        {
            var response =
                await httpClient.DeleteAsync($"api/ShoppingCart/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CartItemDTO>();
            }

            return default(CartItemDTO);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<List<CartItemDTO>?> GetItems(int userId)
    {
        var response =
            await httpClient.GetAsync($"api/ShoppingCart/{userId}/GetItems");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<CartItemDTO>().ToList();
            }

            return await response.Content
                .ReadFromJsonAsync<List<CartItemDTO>>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(
            $"Http status code: {response.StatusCode} Message: {message}");
    }


    /* public async Task<CartItemDTO?> UpdateQty(
        CartItemQtyUpdateDTO cartItemQtyUpdateDto)
    {
        try
        {
            var jsonRequest = JsonConvert.SerializeObject(cartItemQtyUpdateDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8,
                "application/json-patch+json");

            var response = await httpClient.PatchAsync(
                $"api/ShoppingCart/{cartItemQtyUpdateDto.CartItemId}", content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CartItemDTO>();
            }

            return null;
        }
        catch (Exception)
        {
            //Log exception
            throw;
        }
    }*/


    public event Action<int>? OnCartChanged;

    public void RaiseEventOnCartChanged(int totalQty)
    {
        if (OnShoppingCartChanged != null)
        {
            OnShoppingCartChanged.Invoke(totalQty);
        }
    }
}