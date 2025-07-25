using GodoyTest.Mappings;
using GodoyTest.Models;
namespace GodoyTest.DTOs
{
    public class SearchHistoryDTO : IMapFrom<SearchHistory>
    {
        public DateTime Date { get; set; }
        public string Fact { get; set; }
        public string Query { get; set; }
        public string GifUrl { get; set; }
    }
}
