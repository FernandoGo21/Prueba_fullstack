using GodoyTest.Providers;
using GodoyTest.Providers.Interfaces;

namespace GodoyTest.Providers
{
    public class WordsProvider : IWordsProvider
    {
        /// Conjunto de palabras comunes que deben ser excluidas del procesamiento
        private static readonly HashSet<string> _stopWords = new(StringComparer.OrdinalIgnoreCase)
        {
            "a", "an", "the", "is", "it", "and", "or", "to", "of", "in", "its", "that",
            "should", "not", "no", "yes", "must", "from", "their", "this", "those", "these",
            "he", "she", "they", "you", "are", "was", "were", "will", "would", "have", "has",
            "had", "been", "being", "do", "does", "did", "with", "as", "on", "at", "by", "for",
            "through", "between", "and"
        };
        /// Conjunto de palabras que son sujeto por ende deben ir de primeras
        private static readonly HashSet<string> _whitelist = new(StringComparer.OrdinalIgnoreCase)
        {
            "cat", "cats", "kitten", "kittens", "feline", "felines", "tiger", "tigers", "lion", "lions", "jaguar", "puma", "cheetah", "panther", "leopard", "lynx"
        };

        public HashSet<string> GetStopWords() => _stopWords;

        public HashSet<string> GetWhiteListWords() => _whitelist;

    }
}
