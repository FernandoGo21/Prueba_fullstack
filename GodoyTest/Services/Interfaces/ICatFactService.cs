using GodoyTest.Models;

namespace GodoyTest.Services.Interfaces
{
    public interface ICatFactService
    {
        Task<CatFact?> GetRandomFactString();
    }
}
