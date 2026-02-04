using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using PTE_Model;
using PTE_Repository;

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

        [SwaggerOperation("Create WFD")]
        [HttpPost("WFD")]
        public async Task<IActionResult> CreateWfd(CreateWfdModel create)
        {
            var res = await _wfdService.CreateWfd(create);
            return Created($"/api/WFD/{res.Id}", res);
        }

        [SwaggerOperation("Update WFD")]
        [HttpPut("WFD")]
        public async Task<IActionResult> UpdateWfd(UpdateWfdModel update)
            => Ok(await _wfdService.UpdateWfd(update));

        [SwaggerOperation("Delete WFD")]
        [HttpDelete("WFD/{id}")]
        public async Task<IActionResult> DeleteWfd(int id)
            => Ok(await _wfdService.DeleteWfdById(id));

        [SwaggerOperation("Get WFDs")]
        [HttpPost("WFD/Search/{skip}/{take}")]
        public async Task<IActionResult> GetWfds(int skip, int take, SearchWfdModel search)
            => Ok(await _wfdService.GetWfds(skip, take, search));

        [SwaggerOperation("Upload file")]
        [HttpPost("WFD/File")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is required");
            await using var stream = file.OpenReadStream();

            var result = await _wfdService.UploadFile(stream);

            return Ok(result);
        }

    }
}
