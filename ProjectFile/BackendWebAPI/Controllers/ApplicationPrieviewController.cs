using Data.Dtos;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationPrieviewController : ControllerBase
    {
        private readonly IApplicationPreviewService _applicationPreview;
        public ApplicationPrieviewController(IApplicationPreviewService applicationPreview)
        {
            _applicationPreview = applicationPreview;
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetProgram(string Id)
        {
            var program = await _applicationPreview.GetProgram(Id);
            return program != null ? Ok(program) : BadRequest(program);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProgram(ApplicationPreviewDto preview)
        {
            var program = await _applicationPreview.UpdateProgram(preview);
            return program.StatusCode == 200 ? Ok(program) : BadRequest(program);

        }
    }
}
