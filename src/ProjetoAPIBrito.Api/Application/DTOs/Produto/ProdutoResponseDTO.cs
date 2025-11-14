namespace ProjetoAPIBrito.Api.Application.DTOs.Produto
{
    public class ProdutoResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataInativacao { get; set; }
    }
}