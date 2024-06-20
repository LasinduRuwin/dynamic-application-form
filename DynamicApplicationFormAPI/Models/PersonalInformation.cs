namespace DynamicApplicationFormAPI.Models
{
    public class PersonalInformation
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public PersonalInformationField? Phone { get; set; }
        public PersonalInformationField? Nationality { get; set; }
        public PersonalInformationField? CurrentResidence { get; set; }
        public PersonalInformationField? IdNumber { get; set; }
        public PersonalInformationField? DateOfBirth { get; set; }
        public PersonalInformationField? Gender { get; set; }
    }

}
