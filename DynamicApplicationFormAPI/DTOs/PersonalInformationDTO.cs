namespace DynamicApplicationFormAPI.DTOs
{
    public class PersonalInformationDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public PersonalInformationFieldDTO? Phone { get; set; }
        public PersonalInformationFieldDTO? Nationality { get; set; }
        public PersonalInformationFieldDTO? CurrentResidence { get; set; }
        public PersonalInformationFieldDTO? IdNumber { get; set; }
        public PersonalInformationFieldDTO? DateOfBirth { get; set; }
        public PersonalInformationFieldDTO? Gender { get; set; }
    }

}
