using System.ComponentModel.DataAnnotations;

namespace LocadoraSys.Model
{
    public class Locacao
    {
        [Key]
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int FilmeId { get; set; }
        public Filme Filme { get; set; }

        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }

        public Locacao()
        {

        }

        public Locacao(int id, Cliente cliente, Filme filme, DateTime dataLocacao, DateTime dataDevolucao)
        {
            Id = id;
            Cliente = cliente;
            Filme = filme;
            DataLocacao = dataLocacao;
            DataDevolucao = dataDevolucao;
        }
    }
}
