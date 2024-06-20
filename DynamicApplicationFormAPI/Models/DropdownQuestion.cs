namespace DynamicApplicationFormAPI.Models
{
    public class DropdownQuestion : QuestionBase
    {
        public List<string>? Choices { get; set; }
        public string? Answer { get; set; }
    }

}
