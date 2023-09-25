using Backend;
using Backend.Repository;
using Data.Models;


namespace Data.Repository
{
    public class ProgramDetailsRepo : IProgramDetailsRepo
    {
        private readonly ProgramContext _context;

        public ProgramDetailsRepo(ProgramContext context)
        {
            _context = context;
        }


        public async Task<bool> CreateProgramAsync(ProgramDetails program)
        {
            var newProgram = await _context.ProgramDetails.AddAsync(program);
            var saveProgram = await _context.SaveChangesAsync();
            return saveProgram > 0 ? true : false;

        }
        public async Task<ProgramDetails> GetProgram(string Id)
        {

            var program = await _context.ProgramDetails.FindAsync(Id);
            return program != null ? program : null;
        }
        public async Task<bool> UpdateProgram(ProgramDetails programDetailUpdate)
        {

            var update = _context.ProgramDetails.Update(programDetailUpdate);
            var saveProgram = await _context.SaveChangesAsync();
            return saveProgram > 0 ? true : false;
        }



    }
}
