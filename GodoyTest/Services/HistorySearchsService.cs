using AutoMapper;
using GodoyTest.Data;
using GodoyTest.DTOs;
using GodoyTest.Models;
using GodoyTest.Services.Interfaces;
using GodoyTest.Utils;

namespace GodoyTest.Services
{
    /// <summary>
    /// Servicio encargado de gestionar el historia de busqueda de GIFs
    /// </summary>
    public class HistorySearchsService : IHistorySearchsService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor que recibe el contexto de base de datos mediante inyección de dependencias.
        /// </summary>
        public HistorySearchsService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// Guarda un nuevo registro de búsqueda en la base de datos.
        public async Task SaveSearch(SearchHistoryDTO historyDto)
        {
            var history = _mapper.Map<SearchHistory>(historyDto);
            _context.SearchHistories.Add(history);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Recupera el historial de búsquedas paginado, ordenado desde el más reciente.
        /// </summary>
        /// <param name="page">Número de página (basado en 1).</param>
        /// <param name="pageSize">Tamaño de cada página.</param>
        /// <returns>Un objeto paginado de tipo <see cref="PagedObject{SearchHistory}"/>.</returns>
        public async Task<PagedObject<SearchHistoryDTO>> GetHistorySearchs(int page, int pageSize)
        {
            var query = _context.SearchHistories.OrderByDescending(h => h.Date);
            var pagedEntities = await PaginationHelper.PaginateAsync(query, page, pageSize);
            var dtoList = _mapper.Map<List<SearchHistoryDTO>>(pagedEntities.Items);
            return new PagedObject<SearchHistoryDTO>
            {
                Items = dtoList,
                TotalCount = pagedEntities.TotalCount,
                CurrentPage = pagedEntities.CurrentPage,
                PageSize = pagedEntities.PageSize
            };
        }
    }
}
