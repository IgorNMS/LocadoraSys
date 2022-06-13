using Microsoft.AspNetCore.Mvc;
using LocadoraSys.Model;
using LocadoraSys.Services;

namespace LocadoraSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaosController : ControllerBase
    {
        private LocacaoService _locacaoService;

        public LocacaosController(LocacaoService locacaoService)
        {
            _locacaoService = locacaoService;
        }

        // GET: api/Locacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locacao>>> GetLocacaos()
        {
            if (_locacaoService.BuscaLocacaos == null)
            {
                return NotFound();
            }
            return await _locacaoService.BuscaLocacaos();
        }

        // GET: api/Locacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locacao>> GetLocacao(int id)
        {
            var locacao = await _locacaoService.BuscarLocacaoPorId(id);

            if (locacao == null)
            {
                return NotFound();
            }

            return locacao;
        }

        // PUT: api/Locacaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocacao(Locacao locacao)
        {
            await _locacaoService.AtualizarLocacao(locacao);
            return NoContent();
        }

        // POST: api/Locacaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Locacao>> PostLocacao(Locacao locacao)
        {
            await _locacaoService.InserirLocacao(locacao);
            return CreatedAtAction("GetLocacao", new { id = locacao.Id }, locacao);
        }

        // DELETE: api/Locacaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocacao(int id)
        {
            await _locacaoService.RemoveLocacao(id);
            return NoContent();
        }
    }
}
