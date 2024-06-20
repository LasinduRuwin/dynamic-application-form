using DynamicApplicationFormAPI.DatabaseContext;
using DynamicApplicationFormAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicApplicationFormAPI.Repositories
{
    public class PersonalInformationRepository : IPersonalInformationRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonalInformationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PersonalInformation> GetByIdAsync(Guid id)
        {
            return await _context.PersonalInformations.FindAsync(id);
        }

        public async Task<List<PersonalInformation>> GetAllAsync()
        {
            return await _context.PersonalInformations.ToListAsync();
        }

        public async Task AddAsync(PersonalInformation personalInformation)
        {
            await _context.PersonalInformations.AddAsync(personalInformation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PersonalInformation personalInformation)
        {
            _context.PersonalInformations.Update(personalInformation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var personalInformation = await _context.PersonalInformations.FindAsync(id);
            if (personalInformation != null)
            {
                _context.PersonalInformations.Remove(personalInformation);
                await _context.SaveChangesAsync();
            }
        }
    }

}
