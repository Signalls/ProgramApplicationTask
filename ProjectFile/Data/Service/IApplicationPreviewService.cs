using Data.Dtos;

namespace Data.Service
{
    public interface IApplicationPreviewService
    {
        Task<APIResponseDto> GetProgram(string Id);
        Task<APIResponseDto> UpdateProgram(ApplicationPreviewDto preview);
    }
}
