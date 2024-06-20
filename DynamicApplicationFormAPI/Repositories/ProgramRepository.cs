using DynamicApplicationFormAPI.DatabaseContext;
using DynamicApplicationFormAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicApplicationFormAPI.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgramRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProgramForm?> GetByIdAsync(Guid id)
        {
            return await _context.Programs.FindAsync(id);
        }

        public async Task<List<ProgramForm>> GetAllAsync()
        {
            return await _context.Programs.ToListAsync();
        }

        public async Task AddAsync(ProgramForm program)
        {
            await _context.Programs.AddAsync(program);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProgramForm program)
        {
            _context.Programs.Update(program);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var program = await _context.Programs.FindAsync(id);
            if (program != null)
            {
                _context.Programs.Remove(program);
                await _context.SaveChangesAsync();
            }
        }
    }

}
