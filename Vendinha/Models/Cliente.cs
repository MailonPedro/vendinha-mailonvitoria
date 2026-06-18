using System;
using System.ComponentModel.DataAnnotations;

namespace Vendinha.Models
{
    public class Cliente
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve possuir 11 dígitos.")]
        public string CPF { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        [Range(5, 120, ErrorMessage = "O cliente deve possuir pelo menos 5 anos.")]
        public int Idade
        {
            get
            {
                int idade = DateTime.Today.Year - DataNascimento.Year;

                if (DataNascimento > DateTime.Today.AddYears(-idade))
                {
                    idade--;
                }

                return idade;
            }
        }

        private string email;

        public string EmailFormatado
        {
            get
            {
                return email;
            }
            set
            {
                email = value == null ? "" : value.ToLower();
            }
        }
    }
}