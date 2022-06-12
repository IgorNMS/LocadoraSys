using LocadoraSys.Data;
using LocadoraSys.Model;
using Microsoft.EntityFrameworkCore;

namespace LocadoraSys.Services
{
    public class FilmeService
    {
        private readonly LocadoraSysContext _sysContext;

        public FilmeService(LocadoraSysContext sysContext)
        {
            _sysContext = sysContext;
        }

        public async Task<List<Filme>> BuscaFilmes()
        {
            try
            {
                return await _sysContext.Filmes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }

        public async Task<Filme> BuscarFilmePorId(int id)
        {
            try
            {
                return await _sysContext.Filmes.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }

        public async Task InserirFilme(Filme filme)
        {
            try
            {
                _sysContext.Filmes.Add(filme);
                await _sysContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }

        public async Task RemoveFilme(int id)
        {
            try
            {
                var filme = _sysContext.Filmes.FirstOrDefault(x => x.Id == id);
                _sysContext.Filmes.Remove(filme);
                await _sysContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }

        public async Task AtualizarFilme(Filme filmeAtualizado)
        {
            try
            {
                var filme = _sysContext.Filmes.AnyAsync(x => x.Id == filmeAtualizado.Id);
                _sysContext.Filmes.Update(filmeAtualizado);
                await _sysContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }
    }
}
