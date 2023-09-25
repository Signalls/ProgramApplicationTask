using Data.Dtos;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramDetailsController : ControllerBase
    {
        private readonly IProgramDetailsService _detailsService;

        public ProgramDetailsController(IProgramDetailsService detailsRepo)
        {
            _detailsService = detailsRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgram(ProgramDetailsDto program)
        {
            var newProgram = await _detailsService.CreateProgram(program);
            return newProgram.StatusCode == 200 ? Ok(program) : BadRequest(program);

        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetProgram(string Id)
        {
            var program = await _detailsService.GetProgram(Id);
            return program != null ? Ok(program) : BadRequest(program);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProgram(ProgramDetailUpdateDto programDetailUpdate)
        {
            var program = await _detailsService.UpdateProgram(programDetailUpdate);
            return program.StatusCode == 200 ? Ok(program) : BadRequest(program);

        }
    }
}
