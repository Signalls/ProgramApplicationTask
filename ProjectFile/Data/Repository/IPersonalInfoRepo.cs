using Data.Models;

namespace Data.Repository
{
    public interface IPersonalInfoRepo
    {
        Task<bool> CreatePersonalInfoAsync(PersonalInfo person);
        Task<PersonalInfo> GetPersonalInfoAsync(string Id);
    }
}
