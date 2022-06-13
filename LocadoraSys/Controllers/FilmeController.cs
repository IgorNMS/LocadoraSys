using Microsoft.AspNetCore.Mvc;
using LocadoraSys.Model;
using LocadoraSys.Services;
using LocadoraSys.Data.DTOs;

namespace LocadoraSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmesController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        // GET: api/Filmes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmeDto>>> GetFilmes()
        {
            if (_filmeService.BuscaFilmes == null)
            {
                return NotFound();
            }
            return await _filmeService.BuscaFilmes();
        }

        // GET: api/Filmes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetFilme(int id)
        {
            var filme = await _filmeService.BuscarFilmePorId(id);

            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        // PUT: api/Filmes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilme(Filme filme)
        {
            await _filmeService.AtualizarFilme(filme);
            return NoContent();
        }

        // POST: api/Filmes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            await _filmeService.InserirFilme(filme);
            return CreatedAtAction("GetFilme", new { id = filme.Id }, filme);
        }

        // DELETE: api/Filmes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilme(int id)
        {
            await _filmeService.RemoveFilme(id);
            return NoContent();
        }
    }
}
