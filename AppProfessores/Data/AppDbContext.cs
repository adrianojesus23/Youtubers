using AppProfessores.Models;
using Microsoft.EntityFrameworkCore;

namespace AppProfessores.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Professor> Professores { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
}