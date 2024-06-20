using System.Text.Json.Serialization;

namespace DynamicApplicationFormAPI.DTOs
{
    public class DateQuestionDTO : QuestionBaseDTO
    {
        public DateTime Answer { get; set; }

        public DateQuestionDTO() { }

        [JsonConstructor]
        public DateQuestionDTO(string type, string question, DateTime answer)
            : base(type, question)
        {
            Answer = answer;
        }
    }

}
