using GodoyTest.Models;

namespace GodoyTest.Services.Interfaces
{
    public interface IGiphyService
    {
        Task<GifSearchResult?> SearchGifFromAPI(string fact, int? offset = null);
    }
}
