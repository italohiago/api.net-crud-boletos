using System.ComponentModel.DataAnnotations;

namespace NomeDoProjeto.Models
{
    public class Banco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeBanco { get; set; }

        [Required]
        public string CodigoBanco { get; set; }

        [Required]
        public decimal PercentualJuros { get; set; }
    }
}
