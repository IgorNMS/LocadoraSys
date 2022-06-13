using LocadoraSys.Data;
using LocadoraSys.Data.DTOs;
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

        public async Task<List<FilmeDto>> BuscaFilmes()
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
                var filme = await _sysContext.Filmes.FirstOrDefaultAsync(c => c.Id == id);
                if (filme == null)
                {
                    throw new Exception("Filme não existe!");
                }
                return new Filme
                {
                    Id = filme.Id,
                    Titulo = filme.Titulo,
                    ClassificacaoIndicativa = filme.ClassificacaoIndicativa,
                    Lancamento = filme.Lancamento
                };
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
                FilmeDto newFilmeDto = new FilmeDto
                {
                    Id = filme.Id,
                    Titulo = filme.Titulo,
                    ClassificacaoIndicativa = filme.ClassificacaoIndicativa,
                    Lancamento = filme.Lancamento
                };
                _sysContext.Filmes.Add(newFilmeDto);
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
                var filme = _sysContext.Filmes.FirstOrDefault(x => x.Id == filmeAtualizado.Id);
                if (filme == null)
                {
                    throw new Exception("Filme não existe!");
                }
                filme.Titulo = filmeAtualizado.Titulo;
                filme.ClassificacaoIndicativa = filmeAtualizado.ClassificacaoIndicativa;
                filme.Lancamento = filmeAtualizado.Lancamento;

                _sysContext.Filmes.Update(filme);
                await _sysContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }
    }
}
