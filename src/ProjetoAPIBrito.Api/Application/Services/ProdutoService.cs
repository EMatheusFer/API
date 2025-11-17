using AutoMapper;
using ProjetoAPIBrito.Api.Application.DTOs.Produto;
using ProjetoAPIBrito.Api.Domain.Models;
using ProjetoAPIBrito.Api.Infrastructure.Repository;

namespace ProjetoAPIBrito.Api.Application.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoService(ProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<ProdutoResponseDTO> CriarProdutoAsync(ProdutoInserirRequestDTO dto)
        {
            var produto = _mapper.Map<Produto>(dto);

            var criado = await _repository.Adicionar(produto);

            return _mapper.Map<ProdutoResponseDTO>(criado);
        }


        public async Task<ProdutoResponseDTO?> ObterPorIdAsync(int id)
        {
            var produto = await _repository.ObterPorId(id);

            if (produto == null)
                return null;

            return _mapper.Map<ProdutoResponseDTO>(produto);
        }

        public async Task<List<ProdutoResponseDTO>> ObterTodosAsync()
        {
            var produtos = await _repository.ObterTodosAsync();
            return _mapper.Map<List<ProdutoResponseDTO>>(produtos);
        }
    }
}