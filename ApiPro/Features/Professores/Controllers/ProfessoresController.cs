using ApiPro.Features.Professores.Models;
using ApiPro.Features.Professores.Services;
using ApiPro.Features.Professores.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ApiPro.Features.Professores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessoresController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _professorService.Get();

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _professorService.GetById(id);

            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProfessorViewModel professor)
        {
            var result = await _professorService.Create(professor);

            if (result.IsSuccess)
            {
                var createdProfessor = result.Value; // Assuming result contains the created professor
                return CreatedAtAction(nameof(GetById), new { id = createdProfessor.Id }, createdProfessor);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProfessorViewModel professor)
        {
            var result = await _professorService.Update(id,professor);

            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _professorService.Delete(id);

            return result.IsSuccess ? NoContent() : NotFound(result.Errors);
        }
    }
}
