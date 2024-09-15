namespace ApiPro.Features.Professores.Repositories;

public interface IUnitOfWork
{
    IProfessorRepository Professores { get; }
    Task<int> CompleteAsync();
    void Dispose();
}