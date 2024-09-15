using ApiPro.Features.Professores.Models;

namespace ApiPro.Features.Professores.Repositories;

public interface IProfessorRepository
{
    Task<IEnumerable<Professor>> Get();
    Task<Professor> GetById(int id);
    Task Create(Professor professor);
    Task Update(Professor professor);
    Task Delete(int id);
    Task AddAlunos(List<Aluno> alunos);
    Task UpdateAlunos(List<Aluno> alunos);
}