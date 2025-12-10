using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using PTE_Repository;
using PTE_Model;

namespace PTE_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        private readonly IWfdService _wfdService;

        public ContentController(IWfdService wfdService)
        {
            _wfdService = wfdService;
        }

        [SwaggerOperation("Get WFD by ID")]
        [HttpGet("WFD/{id}")]
        public async Task<IActionResult> GetWfdById(int id)
            => Ok(await _wfdService.GetWfdById(id));

        [SwaggerOperation("Get WFDs")]
        [HttpPost("WFD/Search/{skip}/{take}")]
        public async Task<IActionResult> GetWfds(int skip, int take, SearchWfdModel search)
            => Ok(await _wfdService.GetWfds(skip, take, search));
    }
}
