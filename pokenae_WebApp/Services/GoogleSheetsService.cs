using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class GoogleSheetsService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public GoogleSheetsService(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl;
    }

    public async Task<IList<IList<object>>> GetSheetDataAsync(string spreadsheetId, string sheetName)
    {
        var response = await _httpClient.GetStringAsync($"{_baseUrl}?spreadsheetId={spreadsheetId}&sheetName={sheetName}");
        var data = JsonConvert.DeserializeObject<IList<IList<object>>>(response);
        // 1行目をスキップ
        return data.Skip(1).ToList();
    }
}
