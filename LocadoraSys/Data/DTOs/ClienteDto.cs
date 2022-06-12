using System.ComponentModel.DataAnnotations;

namespace LocadoraSys.Data.DTOs
{
    public class ClienteDto
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Nome { get; set; }
        [MaxLength(11)]
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
