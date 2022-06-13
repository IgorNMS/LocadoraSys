using LocadoraSys.Data;
using LocadoraSys.Data.DTOs;
using LocadoraSys.Model;
using Microsoft.EntityFrameworkCore;

namespace LocadoraSys.Services
{
    public class LocacaoService
    {
        private readonly LocadoraSysContext _sysContext;

        public LocacaoService(LocadoraSysContext sysContext)
        {
            _sysContext = sysContext;
        }

        public async Task<List<Locacao>> BuscaLocacaos()
        {
            try
            {
                var locacoes = await _sysContext.Locacao.ToListAsync();

                return locacoes.Select(locacoes => new Locacao()
                {
                    Id = locacoes.Id,

                    DataLocacao = locacoes.DataLocacao,
                    DataDevolucao = locacoes.DataDevolucao,

                    IdCliente = _sysContext.Clientes.FirstOrDefault(c => c.Id == locacoes.Id_Cliente).Id,
                    NomeCliente = _sysContext.Clientes.FirstOrDefault(c => c.Id == locacoes.Id_Cliente).Nome,

                    IdFilme = _sysContext.Filmes.FirstOrDefault(f => f.Id == locacoes.Id_Filme).Id,
                    TituloFilme = _sysContext.Filmes.FirstOrDefault(f => f.Id == locacoes.Id_Filme).Titulo
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }

        public async Task<Locacao> BuscarLocacaoPorId(int id)
        {
            try
            {
                var locacao = await _sysContext.Locacao.FirstOrDefaultAsync(c => c.Id == id);
                if (locacao == null)
                {
                    throw new Exception("Locacao não existe!");
                }
                return new Locacao
                {
                    Id = locacao.Id,
                    DataLocacao = locacao.DataLocacao,
                    DataDevolucao = locacao.DataDevolucao,
                    IdCliente = _sysContext.Clientes.FirstOrDefault(c => c.Id == locacao.Id_Cliente).Id,
                    NomeCliente = _sysContext.Clientes.FirstOrDefault(c => c.Id == locacao.Id_Cliente).Nome,
                    IdFilme = _sysContext.Filmes.FirstOrDefault(f => f.Id == locacao.Id_Filme).Id,
                    TituloFilme = _sysContext.Filmes.FirstOrDefault(f => f.Id == locacao.Id_Filme).Titulo
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }

        public async Task InserirLocacao(Locacao locacao)
        {
            try
            {
                LocacaoDto newLocacaoDto = new LocacaoDto
                {
                    Id = locacao.Id,
                    Id_Cliente = locacao.IdCliente,
                    Id_Filme = locacao.IdFilme,
                    DataLocacao = locacao.DataLocacao
                };

                sbyte lancamento = _sysContext.Filmes.FirstOrDefaultAsync(f => f.Id == locacao.IdFilme).Result.Lancamento;

                if (lancamento == 1)
                {
                    newLocacaoDto.DataDevolucao = locacao.DataLocacao.AddDays(2.0);
                }
                else if (lancamento == 0)
                {
                    newLocacaoDto.DataDevolucao = locacao.DataLocacao.AddDays(3.0);
                }

                _sysContext.Locacao.Add(newLocacaoDto);
                await _sysContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }

        public async Task RemoveLocacao(int id)
        {
            try
            {
                var locacao = _sysContext.Locacao.FirstOrDefault(x => x.Id == id);
                _sysContext.Locacao.Remove(locacao);
                await _sysContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }

        public async Task AtualizarLocacao(Locacao locacaoAtualizado)
        {
            try
            {
                var locacao = _sysContext.Locacao.FirstOrDefault(x => x.Id == locacaoAtualizado.Id);
                if (locacao == null)
                {
                    throw new Exception("Locacao não existe!");
                }
                locacao.Id_Cliente = locacaoAtualizado.Id;
                locacao.Id_Filme = locacaoAtualizado.IdFilme;

                if (!string.IsNullOrEmpty(locacaoAtualizado.DataLocacao.ToShortDateString()))
                    locacao.DataLocacao = locacaoAtualizado.DataLocacao;
                else
                    locacao.DataLocacao = DateTime.Now;

                if (!string.IsNullOrEmpty(locacaoAtualizado.DataDevolucao.ToShortDateString()))
                    locacao.DataDevolucao = locacaoAtualizado.DataDevolucao;

                _sysContext.Locacao.Update(locacao);
                await _sysContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }
    }
}
