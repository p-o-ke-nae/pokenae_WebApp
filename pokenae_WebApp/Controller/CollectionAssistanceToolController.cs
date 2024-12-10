using Microsoft.AspNetCore.Mvc;
using pokenae_WebApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pokenae_WebApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionAssistanceToolController : ControllerBase
    {
        private readonly IGoogleAppsScriptService _googleAppsScriptService;

        public CollectionAssistanceToolController(IGoogleAppsScriptService googleAppsScriptService)
        {
            _googleAppsScriptService = googleAppsScriptService;
        }

        [HttpPost("addRow")]
        public async Task<IActionResult> AddRow([FromBody] Dictionary<string, string> data)
        {
            var result = await _googleAppsScriptService.AddRowAsync(data);
            if (result)
            {
                return Ok(new { status = "success" });
            }
            return StatusCode(500, new { status = "error" });
        }

        [HttpGet("getSheetData/{spreadsheetId}/{sheetName}")]
        public async Task<IActionResult> GetSheetData(string spreadsheetId, string sheetName)
        {
            var data = await _googleAppsScriptService.GetSheetDataAsync(spreadsheetId, sheetName);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound(new { status = "error", message = "Data not found" });
        }

        [HttpPost("clearAndArchive")]
        public async Task<IActionResult> ClearAndArchive([FromBody] Dictionary<string, string> data)
        {
            if (!data.ContainsKey("spreadsheetId"))
            {
                return BadRequest(new { status = "error", message = "Spreadsheet ID is required" });
            }

            var spreadsheetId = data["spreadsheetId"];
            var result = await _googleAppsScriptService.ClearAndArchiveAsync(spreadsheetId);
            if (result)
            {
                return Ok(new { status = "success" });
            }
            return StatusCode(500, new { status = "error" });
        }
    }
}
