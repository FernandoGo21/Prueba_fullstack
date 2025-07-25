using GodoyTest.Models;
using GodoyTest.Services.Interfaces;
using System.Net.Http;
using System.Text.Json;

namespace GodoyTest.Services
{
    /// <summary>
    /// Servicio responsable de interactuar con la API de Giphy y retornar resultados según un hecho
    /// </summary>
    public class GiphyService : IGiphyService
    {
        private readonly HttpClient _httpClient;
        private readonly IQueryExtractorService _queryExtractor;
        // APIKey necesaria para consumir la API de Giphy
        private const string apiKey = "voaNIOg1u7ONPbckzWK71C48YqCOkhVP";
        // Endpoint base de búsqueda en Giphy
        private const string GiphySearchEndpoint = "https://api.giphy.com/v1/gifs/search";
        /// <summary>
        /// Constructor que inyecta el cliente HTTP y el servicio de extracción de consultas.
        /// </summary>
        public GiphyService(HttpClient httpClient, IQueryExtractorService queryExtractor)
        {
            _httpClient = httpClient;
            _queryExtractor = queryExtractor;
        }
        /// <summary>
        /// Realiza una búsqueda de GIF en la API de Giphy con base en un hecho (fact).
        /// </summary>
        /// <param name="fact">Texto base desde el cual se extraerá una consulta.</param>
        /// <param name="offset">Desplazamiento para paginación de resultados (opcional).</param>
        /// <returns>Un objeto GifSearchResult con el resultado de la búsqueda o null si falla.</returns>
        public async Task<GifSearchResult?> SearchGifFromAPI(string fact, int? offset = null)
        {
            // Extraer la consulta de 3 palabras del texto
            var query = _queryExtractor.ExtractQuery(fact);

            int gifOffset = offset ?? 0;
            // Construcción segura del URL
            var url = $"{GiphySearchEndpoint}?api_key={apiKey}&q={Uri.EscapeDataString(query)}&offset={gifOffset}&limit=1";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            // Parseo del JSON y obtención segura del primer resultado
            using var doc = JsonDocument.Parse(json);

            var gifUrl = doc.RootElement
                .GetProperty("data")
                .EnumerateArray()
                .FirstOrDefault()
                .GetProperty("images")
                .GetProperty("original")
                .GetProperty("url")
                .GetString();

            return new GifSearchResult { Fact = fact,
                Query = query,
                GifURL = gifUrl 
            };
        }
    }
}
