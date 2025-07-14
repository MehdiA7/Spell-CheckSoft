using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinUiProject.Services.Api
{
    class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<SendPromptApiResponse> SendPrompt(string apiUrl, object body)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(body);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    return JsonSerializer.Deserialize<SendPromptApiResponse>(responseContent, options);
                }
                else
                {
                    throw new Exception($"Error status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error bro: {ex.Message}");
            }
        }
    }
}
