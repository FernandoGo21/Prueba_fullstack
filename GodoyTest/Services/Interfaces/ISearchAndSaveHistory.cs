using GodoyTest.Models;

namespace GodoyTest.Services.Interfaces
{
    public interface ISearchAndSaveHistory
    {
        Task<GifSearchResult?> SearchAndSaveGif(string fact, int? offset = null);
    }
}
