namespace App.OOP;

public class Livro
{
    protected string TituloPai { get; set; }
    public string Autor { get; set; }
    public int Paginas { get; set; }

    public Livro(string tituloPai, string autor, int paginas)
    {
        TituloPai = tituloPai;
        Autor = autor;
        Paginas = paginas;
    }

    public string GetTitulo()
    {
        return TituloPai;
    }

    public string GetAutor()
    {
        return Autor;
    }

    public virtual void Ler()
    {
        Console.WriteLine("Ler o livro");
    }

    public static IEnumerable<Livro> GetLivros()
    {
        return new List<Livro>()
        {
            new Livro("C#", "Jesus", 200),
            new Livro("SQL", "Pedro", 300),
            new Livro("C#", "Miguel", 100)
        };
    }

    public static List<Livro> GetListLivros()
    {
        return new List<Livro>()
        {
            new Livro("Exist()", "Jesus", 20),
            new Livro("Any()", "Pedro", 30),
            new Livro("Count()", "Miguel", 10)
        };
    }
}