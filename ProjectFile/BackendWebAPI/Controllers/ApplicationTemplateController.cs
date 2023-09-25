using Data.Dtos;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationTemplateController : ControllerBase
    {

        private readonly IApplicationTemplateService _applicationTemplate;

        public ApplicationTemplateController(IApplicationTemplateService applicationTemplate)
        {

            _applicationTemplate = applicationTemplate;
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetProgram(string Id)
        {
            var program = await _applicationTemplate.GetProgram(Id);
            return program != null ? Ok(program) : BadRequest(program);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProgram([FromForm] ApplicationTemplateRequestDto templateRequestDto)
        {
            var program = await _applicationTemplate.UpdateProgram(templateRequestDto);
            return program.StatusCode == 200 ? Ok(program) : BadRequest(program);

        }
    }
}
