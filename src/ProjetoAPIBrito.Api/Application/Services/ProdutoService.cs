using AutoMapper;
using ProjetoAPIBrito.Api.Application.DTOs.Produto;
using ProjetoAPIBrito.Api.Domain.Models;
using ProjetoAPIBrito.Api.Infrastructure.Repository;

namespace ProjetoAPIBrito.Api.Application.Services
{
    public class ProdutoService(ProdutoRepository repository, IMapper mapper)
    {
        private readonly ProdutoRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Produto> CriarProdutoAsync(ProdutoInserirRequestDTO dto)
        {
            
            var produto = _mapper.Map<Produto>(dto);

            return await _repository.Adicionar(produto);
        }

        public async Task<ProdutoResponseDTO> ObterPorId(int id)
        {
            var produto = await _repository.ObterPorId(id);

            return _mapper.Map<ProdutoResponseDTO>(produto); 
        }
    }
}