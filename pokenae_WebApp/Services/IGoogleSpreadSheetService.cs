namespace pokenae_WebApp.Services
{
    public interface IGoogleSpreadSheetService
    {
        Task<bool> AddRowAsync(Dictionary<string, string> data);
        Task<IList<IList<object>>> GetSheetDataAsync(string spreadsheetId, string sheetName);
        Task<bool> ClearAndArchiveAsync(string spreadsheetId);
    }
}
