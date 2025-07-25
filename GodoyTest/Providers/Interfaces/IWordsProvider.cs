namespace GodoyTest.Providers.Interfaces
{
    /// Define un proveedor de palabras que pueden ser filtradas del texto.
    public interface IWordsProvider { 
        /// retorna un conjunto de palabras vacías.</returns>
        HashSet<string> GetStopWords();
        HashSet<string> GetWhiteListWords();
    }
}
