using System.Text.Json.Serialization;

namespace DynamicApplicationFormAPI.DTOs
{
    public class MultipleChoiceQuestionDTO : QuestionBaseDTO
    {
        public List<string>? Choices { get; set; }
        public int MaxChoicesAllowed { get; set; }
        public List<string>? Answer { get; set; }

        public MultipleChoiceQuestionDTO() { }

        [JsonConstructor]
        public MultipleChoiceQuestionDTO(string type, string question, List<string> choices, int maxChoicesAllowed, List<string> answer)
            : base(type, question)
        {
            Choices = choices;
            MaxChoicesAllowed = maxChoicesAllowed;
            Answer = answer;
        }
    }

}
