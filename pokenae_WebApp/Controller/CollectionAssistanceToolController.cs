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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Dictionary<string, string> data)
        {
            var result = await _googleAppsScriptService.AddRowAsync(data);
            if (result)
            {
                return Ok(new { status = "success" });
            }
            return StatusCode(500, new { status = "error" });
        }

        [HttpGet("{spreadsheetId}/{sheetName}")]
        public async Task<IActionResult> Get(string spreadsheetId, string sheetName)
        {
            var data = await _googleAppsScriptService.GetSheetDataAsync(spreadsheetId, sheetName);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound(new { status = "error", message = "Data not found" });
        }
    }
}
