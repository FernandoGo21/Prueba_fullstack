using GodoyTest.DTOs;
using GodoyTest.Models;
using GodoyTest.Services.Interfaces;

namespace GodoyTest.Services
{
    /// <summary>
    /// Servicio encargado de coordinar la búsqueda de un GIF y generar un guardado de la busqueda.
    /// </summary>
    public class SearchAndSaveHistory : ISearchAndSaveHistory
    {
        private readonly IGiphyService _giphyService;
        private readonly IHistorySearchsService _historyService;

        public SearchAndSaveHistory(IGiphyService giphyService, IHistorySearchsService historyService)
        {
            _giphyService = giphyService;
            _historyService = historyService;
        }

        public async Task<GifSearchResult?> SearchAndSaveGif(string fact, int? offset = null)
        {
            var gifResult = await _giphyService.SearchGifFromAPI(fact, offset);
            if (gifResult != null)
            {
                // Si se obtiene un resultado válido, se guarda en el historial
                await _historyService.SaveSearch(new SearchHistoryDTO
                {
                    Date = DateTime.Now,
                    Fact = gifResult.Fact,
                    Query = gifResult.Query,
                    GifUrl = gifResult.GifURL
                });
            }
            return gifResult;
        }
    }
}
