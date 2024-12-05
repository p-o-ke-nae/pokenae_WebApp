using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pokenae_WebApp.Pages
{
    public class CollectionAssistanceToolModel : PageModel
    {
        private readonly GoogleSheetsService _googleSheetsService;

        public CollectionAssistanceToolModel(GoogleSheetsService googleSheetsService)
        {
            _googleSheetsService = googleSheetsService;
        }

        public IList<ColumnInfo> Columns { get; private set; }

        public class ColumnInfo
        {
            public string Id { get; set; }
            public string Header { get; set; }
            public string Width { get; set; }
            public bool IsVisible { get; set; }
        }

        public async Task OnGetAsync()
        {
            var spreadsheetId = "15vjM0HD16LGA7f9hLZC3DZIZaYnbOD41rPKI5gezh0c";
            var colData = await _googleSheetsService.GetSheetDataAsync(spreadsheetId, "Col");
            Columns = new List<ColumnInfo>();

            foreach (var row in colData)
            {
                if (row.Count >= 4)
                {
                    Columns.Add(new ColumnInfo
                    {
                        Id = row[0]?.ToString(),
                        Header = row[1]?.ToString(),
                        Width = row[2]?.ToString(),
                        IsVisible = bool.TryParse(row[3]?.ToString(), out var isVisible) && isVisible
                    });
                }
            }

        }
    }
}
