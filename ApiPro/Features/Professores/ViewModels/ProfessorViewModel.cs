namespace ApiPro.Features.Professores.ViewModels;

public class ProfessorViewModel
{
    public string Name { get; set; }
    public ICollection<string> Alunos { get; set; } = new List<String>();
}