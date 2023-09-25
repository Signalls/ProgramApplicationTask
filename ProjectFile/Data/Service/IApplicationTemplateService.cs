using Data.Dtos;

namespace Data.Service
{
    public interface IApplicationTemplateService
    {
        Task<APIResponseDto> UpdateProgram(ApplicationTemplateRequestDto templateRequestDto);
        Task<APIResponseDto> GetProgram(string Id);
    }
}
