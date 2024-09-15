using AppProfessores.Data;
using AppProfessores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppProfessores.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfessoresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessores()
        {
            var professores = await _context.Professores.ToListAsync();
            if (professores == null || professores.Count == 0)
            {
                return NotFound("No professores found.");
            }

            return Ok(professores);
        }
    }
}
