using GodoyTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GodoyTest.Controllers
{
    [ApiController]
    [Route("api/history")]
    public class HistorySearchsController : ControllerBase
    {
        private readonly IHistorySearchsService _historyService;

        public HistorySearchsController(IHistorySearchsService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistorySearchs([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _historyService.GetHistorySearchs(page, pageSize);
            return Ok(result);
        }
    }
}
