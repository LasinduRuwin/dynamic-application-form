using System.Text.Json.Serialization;

namespace DynamicApplicationFormAPI.DTOs
{
    public class YesNoQuestionDTO : QuestionBaseDTO
    {
        public bool Answer { get; set; }

        public YesNoQuestionDTO() { }

        [JsonConstructor]
        public YesNoQuestionDTO(string type, string question, bool answer)
            : base(type, question)
        {
            Answer = answer;
        }
    }

}
