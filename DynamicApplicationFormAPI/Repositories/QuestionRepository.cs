using DynamicApplicationFormAPI.DatabaseContext;
using DynamicApplicationFormAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicApplicationFormAPI.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<QuestionBase> GetByIdAsync(Guid id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<List<QuestionBase>> GetAllAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task AddAsync(QuestionBase question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(QuestionBase question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }
    }

}
