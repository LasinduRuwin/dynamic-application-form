using DynamicApplicationFormAPI.DTOs;
using DynamicApplicationFormAPI.Models;
using DynamicApplicationFormAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicApplicationFormAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(QuestionBaseDTO questionDto)
        {
            QuestionBase question = MapToQuestionModel(questionDto);
            question.Id = Guid.NewGuid();

            await _questionRepository.AddAsync(question);
            return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, question);
        }

        private QuestionBase MapToQuestionModel(QuestionBaseDTO questionDto)
        {
            switch (questionDto.Type)
            {
                case "Paragraph":
                    return new ParagraphQuestion
                    {
                        Type = questionDto.Type,
                        Question = questionDto.Question,
                        Answer = ((ParagraphQuestionDTO)questionDto).Answer
                    };
                case "Numeric":
                    return new NumericQuestion
                    {
                        Type = questionDto.Type,
                        Question = questionDto.Question,
                        Answer = ((NumericQuestionDTO)questionDto).Answer
                    };
                case "Date":
                    return new DateQuestion
                    {
                        Type = questionDto.Type,
                        Question = questionDto.Question,
                        Answer = ((DateQuestionDTO)questionDto).Answer
                    };
                case "Dropdown":
                    return new DropdownQuestion
                    {
                        Type = questionDto.Type,
                        Question = questionDto.Question,
                        Choices = ((DropdownQuestionDTO)questionDto).Choices,
                        Answer = ((DropdownQuestionDTO)questionDto).Answer
                    };
                case "YesNo":
                    return new YesNoQuestion
                    {
                        Type = questionDto.Type,
                        Question = questionDto.Question,
                        Answer = ((YesNoQuestionDTO)questionDto).Answer
                    };
                case "MultipleChoice":
                    return new MultipleChoiceQuestion
                    {
                        Type = questionDto.Type,
                        Question = questionDto.Question,
                        Choices = ((MultipleChoiceQuestionDTO)questionDto).Choices,
                        MaxChoicesAllowed = ((MultipleChoiceQuestionDTO)questionDto).MaxChoicesAllowed,
                        Answer = ((MultipleChoiceQuestionDTO)questionDto).Answer
                    };
                default:
                    throw new ArgumentException("Invalid question type");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(Guid id)
        {
            var question = await _questionRepository.GetByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _questionRepository.GetAllAsync();
            return Ok(questions);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(Guid id, QuestionBaseDTO questionDto)
        {
            var question = await _questionRepository.GetByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            QuestionBase updatedQuestion = MapToQuestionModel(questionDto);
            updatedQuestion.Id = id;

            await _questionRepository.UpdateAsync(updatedQuestion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {
            await _questionRepository.DeleteAsync(id);
            return NoContent();
        }
    }

}
