using DynamicApplicationFormAPI.Models;

namespace DynamicApplicationFormAPI.Repositories
{
    public interface IQuestionRepository
    {
        Task AddAsync(QuestionBase question);
        Task DeleteAsync(Guid id);
        Task<List<QuestionBase>> GetAllAsync();
        Task<QuestionBase> GetByIdAsync(Guid id);
        Task UpdateAsync(QuestionBase question);
    }
}