using AutoMapper;
using Backend.Repository;
using Data.Dtos;
using Data.Models;

namespace Data.Service
{
    public class WorkFlowServices : IWorkFlowServices
    {
        private readonly IProgramDetailsRepo _programDetails;
        private readonly IMapper _mapper;

        public WorkFlowServices(IProgramDetailsRepo programDetails, IMapper mapper)
        {
            _programDetails = programDetails;
            _mapper = mapper;
        }

        public async Task<APIResponseDto> UpdateProgram(WorkFlowDto workFlow)
        {
            var response = new APIResponseDto();
            var program = _mapper.Map<ProgramDetails>(workFlow);
            var updatedProgram = await _programDetails.UpdateProgram(program);
            if(updatedProgram)
            {
                response.StatusCode = 200;
                response.Message = "Program updated successfully";
                return response;

            }
            response.StatusCode = 500;
            response.Data = null;
            response.Message = "Failed";
            return response;

        }
        public async Task<APIResponseDto> GetProgram(string Id)
        {
            var response = new APIResponseDto();


            var program = await _programDetails.GetProgram(Id);
            var WorkflowProgram = _mapper.Map<WorkFlowDto>(program);
            if(program == null)
            {
                response.StatusCode = 500;
                response.Data = null;
                response.Message = "Failed";
            }
            response.StatusCode = 200;
            response.Message = "Success";
            response.Data = WorkflowProgram;
            return response;



        }
    }
}
