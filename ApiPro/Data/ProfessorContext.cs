using ApiPro.Features.Professores.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPro.Data;

public class ProfessorContext : DbContext
{
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public ProfessorContext(DbContextOptions<ProfessorContext> dbContextOptions) : base(dbContextOptions)
    {

    }
}