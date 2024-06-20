namespace DynamicApplicationFormAPI.Models
{
    public class MultipleChoiceQuestion : QuestionBase
    {
        public List<string>? Choices { get; set; }
        public int MaxChoicesAllowed { get; set; }
        public List<string>? Answer { get; set; }
    }

}
