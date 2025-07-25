using GodoyTest.Models;
using GodoyTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GodoyTest.Controllers
{
    [ApiController]
    [Route("api/")]
    public class GiphyController : ControllerBase
    {
        private readonly IGiphyService _giphyService;
        private readonly IHistorySearchsService _historyService;
        private readonly IQueryExtractorService _queryExtractor;
        private readonly ISearchAndSaveHistory _searchAndSaveHistory;

        public GiphyController(
            IGiphyService giphyService,
            IHistorySearchsService historyService,
            IQueryExtractorService queryExtractor,
            ISearchAndSaveHistory searchAndSaveHistory)
        {
            _giphyService = giphyService;
            _historyService = historyService;
            _queryExtractor = queryExtractor;
            _searchAndSaveHistory = searchAndSaveHistory;
        }

        [HttpGet("gif")]
        public async Task<IActionResult> GetGifByFact([FromQuery] string fact)
        {
            if (string.IsNullOrWhiteSpace(fact)) return BadRequest("Se requieren el hecho para poder retornar un gif relacionado.");

            var gif = await _searchAndSaveHistory.SearchAndSaveGif(fact);

            if (gif == null)
                return NotFound("No se encontró ningún GIF para esta búsqueda.");

            return Ok(gif);
        }
        [HttpGet("otherGif")]
        public async Task<IActionResult> GetRandomGifByQuery([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Se requiere un query para buscar un GIF.");

            var offset = new Random().Next(0, 100);

            var gif = await _giphyService.SearchGifFromAPI(query, offset);

            if (gif == null)
                return NotFound("No se encontró ningún GIF para esta búsqueda.");

            return Ok(gif);
        }
    }
}
