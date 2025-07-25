using GodoyTest.DTOs;
using GodoyTest.Models;

namespace GodoyTest.Services.Interfaces
{
    public interface IHistorySearchsService
    {
        Task SaveSearch(SearchHistoryDTO history);
        Task<PagedObject<SearchHistoryDTO>> GetHistorySearchs(int page, int pageSize);
    }
}
