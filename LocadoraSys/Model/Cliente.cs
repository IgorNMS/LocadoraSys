using System.ComponentModel.DataAnnotations;

namespace LocadoraSys.Model
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Nome { get; set; }
        [StringLength(11)]
        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }

        public ICollection<Locacao> Locacoes { get; set; }

        public Cliente()
        {

        }

        public Cliente(int id, string nome, string cpf, DateTime dataDeNascimento)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            DataDeNascimento = dataDeNascimento;
        }
    }
}
