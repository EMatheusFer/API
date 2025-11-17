using System.Collections;
using Microsoft.EntityFrameworkCore;
using ProjetoAPIBrito.Api.Infrastructure.Data;
using ProjetoAPIBrito.Api.Domain.Models;

namespace ProjetoAPIBrito.Api.Infrastructure.Repository
{
    public class ProdutoRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<Produto> Adicionar(Produto produto)
        {
            produto.Ativo = true;
            produto.DataInativacao = null;

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task Inativar(Produto produto)
        {
            produto.Ativo = false;
            produto.DataInativacao = DateTime.UtcNow;

            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Reativar(Produto produto)
        {
            produto.Ativo = true;
            produto.DataInativacao = null;

            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produto>> ObterTodos(Produto produto)
        {
            return await _context.Produtos.ToListAsync();
        }
        public async Task<Produto?> ObterPorId(int id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Produto>> ObterTodosAsync()
        {
            return await _context.Produtos
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }
    }
}