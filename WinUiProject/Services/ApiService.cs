using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinUiProject.Services
{
    class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> SendPrompt(string apiUrl, object body)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(body);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }else
                {
                    return $"Error status: {response.StatusCode}";
                }
            }catch (Exception ex)
            {
                return $"Error bro: {ex.Message}";
            }
        }
    }
}
