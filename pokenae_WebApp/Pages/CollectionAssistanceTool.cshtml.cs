using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pokenae_WebApp.Pages
{
    public class CollectionAssistanceToolModel : PageModel
    {
        private readonly GoogleSheetsService _googleSheetsService;

        [BindProperty(SupportsGet = true)]
        public string SpreadsheetId { get; set; }

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
            if (string.IsNullOrEmpty(SpreadsheetId))
            {
                // スプレッドシートのリンクが指定されていない場合の処理
                Columns = new List<ColumnInfo>();
                return;
            }

            var colData = await _googleSheetsService.GetSheetDataAsync(SpreadsheetId, "Column");
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
