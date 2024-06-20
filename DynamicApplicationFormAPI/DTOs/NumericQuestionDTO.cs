using System.Text.Json.Serialization;

namespace DynamicApplicationFormAPI.DTOs
{
    public class NumericQuestionDTO : QuestionBaseDTO
    {
        public double Answer { get; set; }
        public NumericQuestionDTO() { }

        [JsonConstructor]
        public NumericQuestionDTO(string type, string question, double answer)
            : base(type, question)
        {
            Answer = answer;
        }
    }

}
