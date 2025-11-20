namespace ProjetoAPIBrito.Api.Application.DTOs.Produto
{
    public class ProdutoInserirRequestDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
    }
}