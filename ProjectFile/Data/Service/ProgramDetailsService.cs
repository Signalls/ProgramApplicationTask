using AutoMapper;
using Backend.Repository;
using Data.Dtos;
using Data.Models;

namespace Data.Service
{
    public class ProgramDetailsService : IProgramDetailsService
    {
        private readonly IProgramDetailsRepo _program;
        private readonly IMapper _mapper;

        public ProgramDetailsService(IProgramDetailsRepo program, IMapper mapper)
        {
            _program = program;
            _mapper = mapper;
        }

        public async Task<APIResponseDto> CreateProgram(ProgramDetailsDto program)
        {
            var response = new APIResponseDto();
            var newprogram = _mapper.Map<ProgramDetails>(program);
            var programDetails = await _program.CreateProgramAsync(newprogram);
            if(programDetails)
            {
                response.StatusCode = 200;
                response.Message = "Program created successfully";
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
            var programDetails = await _program.GetProgram(Id);
            var program = _mapper.Map<ProgramDetailsDto>(programDetails);
            if(program != null)
            {
                response.StatusCode = 200;
                response.Message = "Program retrieved successfully";
                response.Data = program;
                return response;

            }
            response.StatusCode = 500;
            response.Data = null;
            response.Message = "Failed";
            return response;

        }
        public async Task<APIResponseDto> UpdateProgram(ProgramDetailUpdateDto programDetailUpdate)
        {
            var response = new APIResponseDto();

            var updateProgram = _mapper.Map<ProgramDetails>(programDetailUpdate);
            var program = await _program.UpdateProgram(updateProgram);
            if(program)
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


    }
}
