using ApiPro.Features.Professores.Models;
using ApiPro.Features.Professores.ViewModels;
using FluentResults;

namespace ApiPro.Features.Professores.Services;

public interface IProfessorService
{
    Task<Result<IEnumerable<Professor>>> Get();
    Task<Result<Professor>> GetById(int id);
    Task<Result<Professor>> Create(ProfessorViewModel professor);
    Task<Result> Update(int id,ProfessorViewModel professor);
    Task<Result> Delete(int id);
}