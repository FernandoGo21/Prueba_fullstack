using GodoyTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GodoyTest.Controllers
{
    [ApiController]
    [Route("api/fact")]
    public class CatFactController : ControllerBase
    {
        private readonly ICatFactService _catFactService;

        public CatFactController(ICatFactService catFactService)
        {
            _catFactService = catFactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRandomFact()
        {
            var fact = await _catFactService.GetRandomFactString();
            if (fact == null) return NotFound("No se pudo obtener el dato aleatorio.");
            return Ok(fact);
        }
    }
}
