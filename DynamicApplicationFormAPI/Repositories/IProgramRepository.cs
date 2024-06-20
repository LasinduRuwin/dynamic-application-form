using DynamicApplicationFormAPI.Models;

namespace DynamicApplicationFormAPI.Repositories
{
    public interface IProgramRepository
    {
        Task AddAsync(ProgramForm program);
        Task DeleteAsync(Guid id);
        Task<List<ProgramForm>> GetAllAsync();
        Task<ProgramForm?> GetByIdAsync(Guid id);
        Task UpdateAsync(ProgramForm program);
    }
}