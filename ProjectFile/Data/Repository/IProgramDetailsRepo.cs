using Data.Models;

namespace Backend.Repository
{
    public interface IProgramDetailsRepo
    {
        Task<bool> CreateProgramAsync(ProgramDetails program);
        Task<ProgramDetails> GetProgram(string Id);
        Task<bool> UpdateProgram(ProgramDetails programDetailUpdate);

    }
}
