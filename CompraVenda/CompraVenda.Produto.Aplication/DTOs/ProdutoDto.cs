namespace CompraVenda.Produto.Domain.DTOs;

public class ProdutoDto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
}