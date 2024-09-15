using ApiPro.Data;
using ApiPro.Features.Professores.Models;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace ApiPro.Features.Professores.Repositories;

public class ProfessorRepository: IProfessorRepository
{
    private readonly ProfessorContext _context;

    public ProfessorRepository(ProfessorContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Professor>> Get()
    {
        return await _context.Professores
            .Include(x => x.Alunos)
            .ToListAsync();
    }

    public async Task<Professor> GetById(int id)
    {
        return await _context.Professores.FindAsync(id);
    }

    public async Task Create(Professor professor)
    {
        _context.Professores.AddAsync(professor);
    }

    public async Task Update(Professor professor)
    {
        _context.Professores.Update(professor);
    }

    public async Task Delete(int id)
    {
        var professor = await _context.Professores.FindAsync(id);
        if (professor is not null)
        {
            _context.Professores.Remove(professor);

        }
    }

    public async Task AddAlunos(List<Aluno> alunos)
    {
        await _context.Alunos.AddRangeAsync(alunos);
    }

    public async Task UpdateAlunos(List<Aluno> alunos)
    {
        await _context.BulkUpdateAsync(alunos);

    }
}