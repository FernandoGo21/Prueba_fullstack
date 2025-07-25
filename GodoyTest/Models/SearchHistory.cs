using System.ComponentModel.DataAnnotations;

namespace GodoyTest.Models
{
    public class SearchHistory
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Fact { get; set; }
        public string Query { get; set; }
        public string GifUrl { get; set; }
    }
}
