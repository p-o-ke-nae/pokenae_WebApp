using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace pokenae_WebApp.Services.Impl
{
    public class GoogleAppsScriptService : IGoogleAppsScriptService
    {
        private readonly HttpClient _httpClient;
        private readonly string _addRowUrl;
        private readonly string _getSheetDataUrl;
        private readonly string _clearAndArchiveUrl;

        public GoogleAppsScriptService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _addRowUrl = configuration["GoogleAppsScript:AddRowUrl"];
            _getSheetDataUrl = configuration["GoogleAppsScript:GetSheetDataUrl"];
            _clearAndArchiveUrl = configuration["GoogleAppsScript:ClearAndArchiveUrl"];
        }

        public async Task<bool> AddRowAsync(Dictionary<string, string> data)
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_addRowUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<IList<IList<object>>> GetSheetDataAsync(string spreadsheetId, string sheetName)
        {
            var response = await _httpClient.GetStringAsync($"{_getSheetDataUrl}?spreadsheetId={spreadsheetId}&sheetName={sheetName}");
            var data = JsonConvert.DeserializeObject<IList<IList<object>>>(response);
            // 1行目をスキップ
            return data.Skip(1).ToList();
        }

        public async Task<bool> ClearAndArchiveAsync(string spreadsheetId)
        {
            var data = new Dictionary<string, string>
            {
                { "spreadsheetId", spreadsheetId }
            };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_clearAndArchiveUrl, content);
            return response.IsSuccessStatusCode;
        }
    }
}
