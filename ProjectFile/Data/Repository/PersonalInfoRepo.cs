using Backend;
using Data.Models;

namespace Data.Repository
{
    public class PersonalInfoRepo : IPersonalInfoRepo
    {
        private readonly ProgramContext _context;

        public PersonalInfoRepo(ProgramContext context)
        {
            _context = context;
        }
        public async Task<bool> CreatePersonalInfoAsync(PersonalInfo person)
        {
            var newProgram = await _context.PersonalInfos.AddAsync(person);
            var saveProgram = await _context.SaveChangesAsync();
            return saveProgram > 0 ? true : false;

        }
        public async Task<PersonalInfo> GetPersonalInfoAsync(string Id)
        {
            var person = await _context.PersonalInfos.FindAsync(Id);

            return person != null ? person : null;

        }
    }
}
