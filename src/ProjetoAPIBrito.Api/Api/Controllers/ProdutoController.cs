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
            var result = await _produtoService.CriarProdutoAsync(dto);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] ProdutoAtualizarRequestDTO dto)
        {
            var atualizado = await _produtoService.AtualizarAsync(id, dto);

            if (atualizado == null)
                return NotFound();

            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Inativar(int id)
        {
            var sucesso = await _produtoService.InativarAsync(id);

            if (!sucesso)
                return NotFound("Produto não encontrado.");

            return NoContent();
        }

        [HttpPatch("{id}/reativar")]
        public async Task<IActionResult> Reativar(int id)
        {
            var produto = await _produtoService.ReativarAsync(id);

            if (produto == null)
                return NotFound(new { mensagem = "Produto não encontrado." });

            return Ok(produto);
        }
    }
}