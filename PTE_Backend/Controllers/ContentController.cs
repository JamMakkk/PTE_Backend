using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using PTE_Repository;

namespace PTE_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        private readonly WfdService _wfdService;

        public ContentController(WfdService wfdService)
        {
            _wfdService = wfdService;
        }

        [SwaggerOperation("Get book by ID")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
            => Ok(await _wfdService.GetWfdById(id));
    }
}
