using System;
using System.ComponentModel.DataAnnotations;

namespace boletos_banco.Data.Models
{
    public class Boleto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do pagador é obrigatório.")]
        public string NomePagador { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF/CNPJ do pagador é obrigatório.")]
        public string CPFCNPJPagador { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome do beneficiário é obrigatório.")]
        public string NomeBeneficiario { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF/CNPJ do beneficiário é obrigatório.")]
        public string CPFCNPJBeneficiario { get; set; } = string.Empty;

        [Required(ErrorMessage = "O valor é obrigatório.")]
        public decimal Valor { get; set; } = 0.0m; 

        [Required(ErrorMessage = "A data de vencimento é obrigatória.")]
        public DateTime DataVencimento { get; set; } = DateTime.MinValue;

        public string Observacao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O banco é obrigatório.")]
        public int BancoId { get; set; } = 0;
    }
}
