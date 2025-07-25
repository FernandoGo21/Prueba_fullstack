using GodoyTest.Models;
using GodoyTest.Services.Interfaces;

namespace GodoyTest.Services
{
    public class CatFactService : ICatFactService
    {
        private readonly HttpClient _http;
        public CatFactService(HttpClient http)
        {
            _http = http;
        }

        public async Task<CatFact?> GetRandomFactString()
        {
            return await _http.GetFromJsonAsync<CatFact>("https://catfact.ninja/fact");
        }
    }
}
