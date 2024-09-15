using Newtonsoft.Json;

namespace AppProfessores.Models;

public class Professor
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonIgnore]
    public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
}