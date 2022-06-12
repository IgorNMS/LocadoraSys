using LocadoraSys.Data;
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
                return await _sysContext.Locacao.ToListAsync();
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
                return await _sysContext.Locacao.FirstOrDefaultAsync(c => c.Id == id);
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
                _sysContext.Locacao.Add(locacao);
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
                var locacao = _sysContext.Locacao.AnyAsync(x => x.Id == locacaoAtualizado.Id);
                _sysContext.Locacao.Update(locacaoAtualizado);
                await _sysContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }
    }
}
