namespace pokenae_WebApp.Services
{
    public interface IGoogleAppsScriptService
    {
        Task<bool> AddRowAsync(Dictionary<string, string> data);
        Task<IList<IList<object>>> GetSheetDataAsync(string spreadsheetId, string sheetName);
    }
}
