using System;
using System.ComponentModel.DataAnnotations;

namespace Vendinha.Models
{
    public class Divida
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatório.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O valor da dívida é obrigatório.")]
        [Range(0.01, 999999.99, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A situação é obrigatória.")]
        [StringLength(20, ErrorMessage = "A situação deve possuir no máximo 20 caracteres.")]
        public string Situacao { get; set; }

        [Required(ErrorMessage = "A data de criação é obrigatória.")]
        public DateTime DataCriacao { get; set; }

        public DateTime? DataPagamento { get; set; }

        public bool EstaPendente
        {
            get
            {
                return Situacao == "Pendente";
            }
        }
    }
}