using Newtonsoft.Json;

namespace ApiPro.Features.Professores.Models;

public class Aluno
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProfessorId { get; set; }
    [JsonIgnore]
    public Professor Professor { get; set; }
}