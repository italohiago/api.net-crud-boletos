using System.ComponentModel.DataAnnotations;

namespace boletos_banco.Data.Models
{
    public class Banco
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do banco é obrigatório.")]
        public string NomeBanco { get; set; } = string.Empty;

        [Required(ErrorMessage = "O código do banco é obrigatório.")]
        public string CodigoBanco { get; set; } = string.Empty;

        [Required(ErrorMessage = "O percentual de juros é obrigatório.")]
        public decimal PercentualJuros { get; set; } = 0.0m; 
    }
}
