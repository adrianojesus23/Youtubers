using ApiPro.Features.Professores.Models;
using ApiPro.Features.Professores.Repositories;
using ApiPro.Features.Professores.ViewModels;
using FluentResults;

namespace ApiPro.Features.Professores.Services;

public class ProfessorService:IProfessorService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProfessorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<IEnumerable<Professor>>> Get()
    {
        var result = await _unitOfWork.Professores.Get();
        
        return Result.Ok(result);
    }

    public async Task<Result<Professor>> GetById(int id)
    {
        var professor = await _unitOfWork.Professores.GetById(id);

        return professor is null ? Result.Fail<Professor>("Professor not found")
                : Result.Ok<Professor>(professor);
    }

    public async Task<Result<Professor>> Create(ProfessorViewModel  professorViewModel)
    {
        var professor = new Professor()
        {
             Name = professorViewModel.Name
        };
        await _unitOfWork.Professores.Create(professor);

        await _unitOfWork.CompleteAsync();
        
        int newProfessorId = professor.Id;

        await CreateAlunos(professorViewModel, newProfessorId, true);
        
        return Result.Ok(professor);
    }

    private async Task CreateAlunos(ProfessorViewModel professorViewModel, int newProfessorId, bool isData)
    {
        if (professorViewModel.Alunos.Any())
        {
            var alunos = new List<Aluno>();
            foreach (var aluno in professorViewModel.Alunos)
            {
                alunos.Add(new Aluno()
                {
                    Name = aluno,
                    ProfessorId = newProfessorId,
                });
            }

            if (isData)
                await _unitOfWork.Professores.AddAlunos(alunos);
            //else
            //    await _unitOfWork.Professores.UpdateAlunos(alunos);

            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task<Result> Update(int id,ProfessorViewModel professorUpdate)
    {
        var professor = await _unitOfWork.Professores.GetById(id);

        if (professor is null)
            return Result.Fail("Professor not found");

        professor.Name = professorUpdate.Name;

        await _unitOfWork.Professores.Update(professor);
        await _unitOfWork.CompleteAsync();

        await CreateAlunos(professorUpdate, id, false);


        return Result.Ok();
    }

    public async Task<Result> Delete(int id)
    {
        var professor = await _unitOfWork.Professores.GetById(id);

        if (professor is null)
            return Result.Fail("Professor not found");
        
       await  _unitOfWork.Professores.Delete(id);

         await _unitOfWork.CompleteAsync();
         
         return Result.Ok();
    }
}

