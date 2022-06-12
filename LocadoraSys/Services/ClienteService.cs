using LocadoraSys.Data;
using LocadoraSys.Model;
using Microsoft.EntityFrameworkCore;

namespace LocadoraSys.Services
{
    public class ClienteService
    {
        private readonly LocadoraSysContext _sysContext;

        public ClienteService(LocadoraSysContext sysContext)
        {
            _sysContext = sysContext;
        }

        public async Task<List<Cliente>> BuscaClientes()
        {
            try
            {
                return await _sysContext.Clientes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message); 
            }
        }

        public async Task<Cliente> BuscarClientePorId(int id)
        {
            try
            {
                return await _sysContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }

        public async Task InserirCliente(Cliente cliente)
        {
            try
            {
                var clientFormatado = new Cliente
                {
                    CPF = cliente.CPF,
                    Nome = cliente.Nome,
                    DataDeNascimento = cliente.DataDeNascimento                    
                };
                _sysContext.Clientes.Add(cliente);
                await _sysContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }

        public async Task RemoveCliente(int id)
        {
            try
            {
                var cliente = _sysContext.Clientes.FirstOrDefault(x => x.Id == id);
                _sysContext.Clientes.Remove(cliente);
                await _sysContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }

        public async Task AtualizarCliente(Cliente clienteAtualizado)
        {
            try
            {
                var cliente = _sysContext.Clientes.AnyAsync(x => x.Id == clienteAtualizado.Id);
                _sysContext.Clientes.Update(clienteAtualizado);
                await _sysContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Erro na conexão com DB " + ex.Message);
            }
        }
    }
}
