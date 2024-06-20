using System.Text.Json.Serialization;

namespace DynamicApplicationFormAPI.DTOs
{
    public class ParagraphQuestionDTO : QuestionBaseDTO
    {
        public string? Answer { get; set; }

        public ParagraphQuestionDTO() { }

        [JsonConstructor]
        public ParagraphQuestionDTO(string type, string question, string answer)
            : base(type, question)
        {
            Answer = answer;
        }
    }

}
