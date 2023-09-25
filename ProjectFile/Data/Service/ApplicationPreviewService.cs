using AutoMapper;
using Backend.Repository;
using Data.Dtos;
using Data.Models;

namespace Data.Service
{
    public class ApplicationPreviewService : IApplicationPreviewService
    {
        private readonly IProgramDetailsRepo _programDetails;
        private readonly IMapper _mapper;

        public ApplicationPreviewService(IProgramDetailsRepo programDetails, IMapper mapper)
        {
            _programDetails = programDetails;
            _mapper = mapper;
        }

        public async Task<APIResponseDto> UpdateProgram(ApplicationPreviewDto applicationPreview)
        {
            var response = new APIResponseDto();

            var program = _mapper.Map<ProgramDetails>(applicationPreview);
            var updatedProgram = await _programDetails.UpdateProgram(program);
            if(updatedProgram)
            {
                response.StatusCode = 200;
                response.Message = "Program updated successfully";
                response.Data = program;
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
            var programPreview = _mapper.Map<ApplicationPreviewDto>(program);
            if(programPreview != null)
            {
                response.StatusCode = 200;
                response.Message = "Program retrieved successfully";
                response.Data = programPreview;
                return response;
            }
            response.StatusCode = 500;
            response.Message = "Failed";
            return response;



        }
    }
}
