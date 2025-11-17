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

        // POST: api/produto
        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] ProdutoInserirRequestDTO dto)
        {
            var result = await _produtoService.CriarProdutoAsync(dto);
            return Ok(result);
        }

        // GET: api/produto?id=1
        [HttpGet]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            var produto = await _produtoService.ObterPorIdAsync(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpGet("todos")]
        public async Task<ActionResult<List<ProdutoResponseDTO>>> ObterTodos()
        {
            var produtos = await _produtoService.ObterTodosAsync();
            return Ok(produtos);
        }
    }
}