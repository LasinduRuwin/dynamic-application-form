using DynamicApplicationFormAPI.Models;

namespace DynamicApplicationFormAPI.Repositories
{
    public interface IPersonalInformationRepository
    {
        Task AddAsync(PersonalInformation personalInformation);
        Task DeleteAsync(Guid id);
        Task<List<PersonalInformation>> GetAllAsync();
        Task<PersonalInformation> GetByIdAsync(Guid id);
        Task UpdateAsync(PersonalInformation personalInformation);
    }
}