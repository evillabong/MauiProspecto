using Common.Param;
using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiProspecto.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpclient)
        {
            _httpClient = httpclient; 
        }

        public async Task<T?> GetAsync<T>(string endpoint) where T : BaseResult
        {
            try
            {
                var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en GET: {ex.Message}");
                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado en GET: {ex.Message}");
                return default;
            }
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data) where TResponse : BaseResult where TRequest : BaseParam
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(endpoint, data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en POST: {ex.Message}");
                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado en POST: {ex.Message}");
                return default;
            }
        }
    }
}
