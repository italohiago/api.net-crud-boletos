using System;
using System.ComponentModel.DataAnnotations;

namespace NomeDoProjeto.Models
{
    public class Boleto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do pagador é obrigatório.")]
        public string NomePagador { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ do pagador é obrigatório.")]
        public string CPFCNPJPagador { get; set; }

        [Required(ErrorMessage = "O nome do beneficiário é obrigatório.")]
        public string NomeBeneficiario { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ do beneficiário é obrigatório.")]
        public string CPFCNPJBeneficiario { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data de vencimento é obrigatória.")]
        public DateTime DataVencimento { get; set; }

        public string Observacao { get; set; }

        [Required(ErrorMessage = "O banco é obrigatório.")]
        public int BancoId { get; set; }
    }
}
