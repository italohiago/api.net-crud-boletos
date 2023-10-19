using System.ComponentModel.DataAnnotations;

namespace NomeDoProjeto.Models
{
    public class Banco
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do banco é obrigatório.")]
        public string NomeBanco { get; set; }

        [Required(ErrorMessage = "O código do banco é obrigatório.")]
        public string CodigoBanco { get; set; }

        [Required](ErrorMessage = "O percentual de juros é obrigatório.")
        public decimal PercentualJuros { get; set; }
    }
}
