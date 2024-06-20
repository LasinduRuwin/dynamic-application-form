namespace DynamicApplicationFormAPI.Models
{
    public class PersonalInformationField
    {
        public string? Value { get; set; }
        public bool IsHidden { get; set; } = false;
        public bool IsInternal { get; set; } = false;
    }

}
