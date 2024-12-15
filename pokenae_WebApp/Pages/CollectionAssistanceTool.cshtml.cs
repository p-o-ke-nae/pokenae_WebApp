using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace pokenae_WebApp.Pages
{
    public class CollectionAssistanceToolModel : PageModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty(SupportsGet = true)]
        public string SpreadsheetId { get; set; }

        public CollectionAssistanceToolModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
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

            var response = await _httpClient.GetAsync($"api/CollectionAssistanceTool/getSheetData/{SpreadsheetId}/Column");
            if (response.IsSuccessStatusCode)
            {
                var colData = await response.Content.ReadFromJsonAsync<IList<IList<object>>>();
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
            else
            {
                Columns = new List<ColumnInfo>();
            }
        }

    }
}
