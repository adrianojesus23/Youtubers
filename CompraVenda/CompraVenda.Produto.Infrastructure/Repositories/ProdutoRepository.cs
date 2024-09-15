using Dapper;
using Microsoft.Data.Sqlite;
using CompraVenda.Produto.Domain.Entities;
using CompraVenda.Produto.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompraVenda.Produto.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _connectionString;

        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Domain.Entities.Produto>> GetAllAsync()
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "SELECT * FROM Produtos";
            return await connection.QueryAsync<Domain.Entities.Produto>(sql);
        }

        public async Task<Domain.Entities.Produto> GetByIdAsync(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "SELECT * FROM Produtos WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Domain.Entities.Produto>(sql, new { Id = id });
        }

        public async Task AddAsync(Domain.Entities.Produto produto)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "INSERT INTO Produtos (Nome, Preco, QuantidadeEstoque) VALUES (@Nome, @Preco, @QuantidadeEstoque)";
            await connection.ExecuteAsync(sql, produto);
        }

        public async Task UpdateAsync(Domain.Entities.Produto produto)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "UPDATE Produtos SET Nome = @Nome, Preco = @Preco, QuantidadeEstoque = @QuantidadeEstoque WHERE Id = @Id";
            await connection.ExecuteAsync(sql, produto);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "DELETE FROM Produtos WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
