using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class ProgramContextService
    {
        private readonly ProgramContext _context;
        public ProgramContextService(ProgramContext context)
        {
            _context = context;
        }
        public DbContext GetContext()
        {
            return _context;
        }
    }
}
