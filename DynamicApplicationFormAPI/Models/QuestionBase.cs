namespace DynamicApplicationFormAPI.Models
{
    public abstract class QuestionBase
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public string? Question { get; set; }
    }

}
