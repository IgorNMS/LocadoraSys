using System.ComponentModel.DataAnnotations;

namespace LocadoraSys.Model
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Titulo { get; set; }
        public sbyte ClassificacaoIndicativa { get; set; }
        public sbyte Lancamento { get; set; }

        public ICollection<Locacao> Locacoes { get; set; }

        public Filme()
        {

        }

        public Filme(int id, string titulo, sbyte classificacaoIndicativa, sbyte lancamento)
        {
            Id = id;
            Titulo = titulo;
            ClassificacaoIndicativa = classificacaoIndicativa;
            Lancamento = lancamento;
        }
    }
}
