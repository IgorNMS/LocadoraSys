using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraSys.Data.DTOs
{
    public class LocacaoDto
    {
        [Key]
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Filme { get; set; }
        [ForeignKey("Id_Cliente")]
        public ClienteDto Cliente { get; set; }
        [ForeignKey("Id_Filme")]
        public FilmeDto Filme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
