using Microsoft.AspNetCore.Mvc;
using ProjetoAPIBrito.Api.Application.DTOs.Produto;
using ProjetoAPIBrito.Api.Application.Services;

namespace ProjetoAPIBrito.Api.Api.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] ProdutoInserirRequestDTO dto)
        {
            var produto = await _produtoService.CriarProdutoAsync(dto);

            
            return Ok(produto);
        }

        [HttpGet]
        public async Task<ProdutoResponseDTO> ObterPorId([FromQuery] int id)
        {
            return await _produtoService.ObterPorId(id);

        }
    }

    public interface IActionResult<T>
    {
    }
}