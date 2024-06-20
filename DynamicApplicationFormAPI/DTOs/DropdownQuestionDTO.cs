using System.Text.Json.Serialization;

namespace DynamicApplicationFormAPI.DTOs
{
    public class DropdownQuestionDTO : QuestionBaseDTO
    {
        public List<string>? Choices { get; set; }
        public string? Answer { get; set; }

        public DropdownQuestionDTO() { }

        [JsonConstructor]
        public DropdownQuestionDTO(string type, string question, List<string> choices, string answer)
            : base(type, question)
        {
            Choices = choices;
            Answer = answer;
        }
    }

}
