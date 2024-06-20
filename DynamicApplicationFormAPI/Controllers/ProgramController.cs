using DynamicApplicationFormAPI.DTOs;
using DynamicApplicationFormAPI.Models;
using DynamicApplicationFormAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicApplicationFormAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramRepository _programRepository;

        public ProgramController(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgram(ProgramFormDTO programDto)
        {
            var program = new ProgramForm
            {
                Id = Guid.NewGuid(),
                Title = programDto.Title,
                Description = programDto.Description
            };

            await _programRepository.AddAsync(program);
            return CreatedAtAction(nameof(GetProgram), new { id = program.Id }, program);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgram(Guid id)
        {
            var program = await _programRepository.GetByIdAsync(id);
            if (program == null)
            {
                return NotFound();
            }
            return Ok(program);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrograms()
        {
            var programs = await _programRepository.GetAllAsync();
            return Ok(programs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgram(Guid id, ProgramFormDTO programDto)
        {
            var program = await _programRepository.GetByIdAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            program.Title = programDto.Title;
            program.Description = programDto.Description;

            await _programRepository.UpdateAsync(program);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(Guid id)
        {
            await _programRepository.DeleteAsync(id);
            return NoContent();
        }
    }

}
