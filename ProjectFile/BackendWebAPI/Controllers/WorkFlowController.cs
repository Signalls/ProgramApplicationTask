using Data.Dtos;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowController : ControllerBase
    {
        private readonly IWorkFlowServices _workFlowServices;
        public WorkFlowController(IWorkFlowServices workFlowServices)
        {
            _workFlowServices = workFlowServices;
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetProgram(string Id)
        {
            var program = await _workFlowServices.GetProgram(Id);
            return program.StatusCode == 200 ? Ok(program) : BadRequest(program);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProgram(WorkFlowDto workFlow)
        {
            var program = await _workFlowServices.UpdateProgram(workFlow);
            return program.StatusCode == 200 ? Ok(program) : BadRequest(program);
        }
    }
}
