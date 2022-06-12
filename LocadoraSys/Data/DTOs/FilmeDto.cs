using System.ComponentModel.DataAnnotations;

namespace LocadoraSys.Data.DTOs
{
    public class FilmeDto
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Titulo { get; set; }
        public sbyte ClassificacaoIndicativa { get; set; }
        public sbyte Lancamento { get; set; }
    }
}
