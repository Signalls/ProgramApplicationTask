using Data.Dtos;

namespace Data.Service
{
    public interface IProgramDetailsService
    {
        Task<APIResponseDto> CreateProgram(ProgramDetailsDto program);
        Task<APIResponseDto> GetProgram(string Id);
        Task<APIResponseDto> UpdateProgram(ProgramDetailUpdateDto programDetailUpdate);


    }
}
