namespace App.OOP;

public class LivroDigital: Livro
{
    public string Titulo { get; set; }
    public decimal Preco { get; set; }
    public LivroDigital(string tituloPai, string autor, int paginas, decimal preco) : base(tituloPai, autor, paginas)
    {
        Preco = preco;
    }

    public override void Ler()
    {
        Console.WriteLine("Ler o livro digital");
    }

    public void Ler(string name)
    {
        Console.WriteLine($"{name} Ler o livro digital");

    }
}