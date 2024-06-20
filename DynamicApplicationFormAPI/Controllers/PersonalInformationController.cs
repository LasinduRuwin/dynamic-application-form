using DynamicApplicationFormAPI.DTOs;
using DynamicApplicationFormAPI.Models;
using DynamicApplicationFormAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicApplicationFormAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonalInformationController : ControllerBase
    {
        private readonly IPersonalInformationRepository _personalInformationRepository;

        public PersonalInformationController(IPersonalInformationRepository personalInformationRepository)
        {
            _personalInformationRepository = personalInformationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonalInformation(PersonalInformationDTO personalInfoDto)
        {
            var personalInfo = new PersonalInformation
            {
                Id = Guid.NewGuid(),
                FirstName = personalInfoDto.FirstName,
                LastName = personalInfoDto.LastName,
                Email = personalInfoDto.Email,
                Phone = MapField(personalInfoDto.Phone),
                Nationality = MapField(personalInfoDto.Nationality),
                CurrentResidence = MapField(personalInfoDto.CurrentResidence),
                IdNumber = MapField(personalInfoDto.IdNumber),
                DateOfBirth = MapField(personalInfoDto.DateOfBirth),
                Gender = MapField(personalInfoDto.Gender)
            };

            await _personalInformationRepository.AddAsync(personalInfo);
            return CreatedAtAction(nameof(GetPersonalInformation), new { id = personalInfo.Id }, personalInfo);
        }

        private PersonalInformationField MapField(PersonalInformationFieldDTO fieldDto)
        {
            return fieldDto == null ? null : new PersonalInformationField
            {
                Value = fieldDto.Value,
                IsHidden = fieldDto.IsHidden,
                IsInternal = fieldDto.IsInternal
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonalInformation(Guid id)
        {
            var personalInfo = await _personalInformationRepository.GetByIdAsync(id);
            if (personalInfo == null)
            {
                return NotFound();
            }
            return Ok(personalInfo);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonalInformations()
        {
            var personalInfos = await _personalInformationRepository.GetAllAsync();
            return Ok(personalInfos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonalInformation(Guid id, PersonalInformationDTO personalInfoDto)
        {
            var personalInfo = await _personalInformationRepository.GetByIdAsync(id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            personalInfo.FirstName = personalInfoDto.FirstName;
            personalInfo.LastName = personalInfoDto.LastName;
            personalInfo.Email = personalInfoDto.Email;
            personalInfo.Phone = MapField(personalInfoDto.Phone);
            personalInfo.Nationality = MapField(personalInfoDto.Nationality);
            personalInfo.CurrentResidence = MapField(personalInfoDto.CurrentResidence);
            personalInfo.IdNumber = MapField(personalInfoDto.IdNumber);
            personalInfo.DateOfBirth = MapField(personalInfoDto.DateOfBirth);
            personalInfo.Gender = MapField(personalInfoDto.Gender);

            await _personalInformationRepository.UpdateAsync(personalInfo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalInformation(Guid id)
        {
            await _personalInformationRepository.DeleteAsync(id);
            return NoContent();
        }
    }

}
