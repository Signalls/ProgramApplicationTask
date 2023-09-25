using Data.Dtos;

namespace Data.Service
{
    public interface IWorkFlowServices
    {
        Task<APIResponseDto> UpdateProgram(WorkFlowDto workFlow);
        Task<APIResponseDto> GetProgram(string Id);

    }
}
