using LocadoraSys.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LocadoraSys.Data
{
    public class LocadoraSysContext : DbContext
    {
        public LocadoraSysContext(DbContextOptions<LocadoraSysContext> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<ClienteDto> Clientes { get; set; }
        public DbSet<FilmeDto> Filmes { get; set; }
        public DbSet<LocacaoDto> Locacao { get; set; }
    }
}
