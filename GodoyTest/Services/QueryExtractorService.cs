using GodoyTest.Providers;
using GodoyTest.Providers.Interfaces;
using GodoyTest.Services.Interfaces;
namespace GodoyTest.Services
{
    /// <summary>
    /// Servicio encargado de extraer una consulta relevante (3 palabras) a partir de un hecho obtenido de la API de Cat Facts.
    /// Aplica filtrado mediante stop words, whitelist y reglas básicas de limpieza.
    /// </summary>
    public class QueryExtractorService : IQueryExtractorService
    {
        private readonly IWordsProvider _wordsProvider;
        /// <summary>
        /// Constructor que inyecta IWordsProvider, Interfaz que provee listas de palabras para filtrado.
        /// </summary>
        public QueryExtractorService(IWordsProvider wordsProvider)
        {
            _wordsProvider = wordsProvider;
        }
        /// <summary>
        /// Extrae una cadena de hasta 3 palabras clave a partir de un hecho, filtrando por stop words, números, longitud mínima, etc.
        /// </summary>
        /// <param name="fact">Hecho proveniente de la API pública de Cat Facts.</param>
        /// <returns>Una cadena con máximo 3 palabras separadas por espacio, relevantes para búsqueda en Giphy.</returns>
        public string ExtractQuery(string fact)
        {
            
            var stopWords = _wordsProvider.GetStopWords();
            var whitelist = _wordsProvider.GetWhiteListWords();
            //Separamos por espacios y puntuación
            var words = fact
                .Split(new[] { ' ', '.', ',', '(', ')', '?', '!', ';', ':' }, StringSplitOptions.RemoveEmptyEntries)
                //ponemos en minuscula todo y quitamos espacios
                .Select(w => w.ToLowerInvariant().Trim())
                .Where(w =>
                    // Filtrar si es una stop word y no está en la whitelist
                    (whitelist.Contains(w) || !stopWords.Contains(w)) &&
                    // Omitir palabras muy cortas (excepto si están en la whitelist)
                    (whitelist.Contains(w) || w.Length > 2) &&
                    // Omitir números o información que empiece con dígitos
                    !w.All(char.IsDigit) &&
                    !char.IsDigit(w[0]))
                .ToList();
            // Agrupar y rankear las palabras por menor frecuencia y mayor longitud
            var rankedWords = words
                .GroupBy(w => w)
                .Select(g => new
                {
                    Word = g.Key,
                    Frequency = g.Count(),
                    Length = g.Key.Length,
                    IsWhitelisted = whitelist.Contains(g.Key)
                })
                .OrderByDescending(w => w.IsWhitelisted) //Primero las que estan en la lista blanca
                .ThenBy(w => w.Frequency) // luego las menos frecuentes
                .ThenByDescending(w => w.Length) // luego las más largas
                .Take(3)
                .Select(w => w.Word);
            // Devolvemos la consulta como string concatenado por espacios como el siguiente "Three words example"
            return string.Join(" ", rankedWords);
        }
    }
}
