using ApiPro.Data;

namespace ApiPro.Features.Professores.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly ProfessorContext _context;
    private IProfessorRepository _professorRepository;
    public UnitOfWork(ProfessorContext context)
    {
        _context = context;
    }

    public IProfessorRepository Professores => _professorRepository ?? new ProfessorRepository(_context);
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}