using GodoyTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GodoyTest.Utils
{
    public static class PaginationHelper
    {
        public static async Task<PagedObject<T>> PaginateAsync<T>(
            IQueryable<T> query,
            int page,
            int pageSize) where T : class
        {
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedObject<T>
            {
                Items = items,
                TotalCount = totalCount,
                CurrentPage = page,
                PageSize = pageSize
            };
        }
    }
}
