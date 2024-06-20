namespace DynamicApplicationFormAPI.DTOs
{
    public abstract class QuestionBaseDTO
    {
        public string? Type { get; set; }
        public string? Question { get; set; }
        protected QuestionBaseDTO() { }

        protected QuestionBaseDTO(string type, string question)
        {
            Type = type;
            Question = question;
        }
    }

}
