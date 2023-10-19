using System.ComponentModel.DataAnnotations;

namespace boletos_banco.Data.Models
{
    public class Banco
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do banco é obrigatório.")]
        public string NomeBanco { get; set; }

        [Required(ErrorMessage = "O código do banco é obrigatório.")]
        public string CodigoBanco { get; set; }

        [Required(ErrorMessage = "O percentual de juros é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O percentual de juros deve ser maior que zero.")]
        public decimal PercentualJuros { get; set; }
    }
}
