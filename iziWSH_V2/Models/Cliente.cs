using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iziWSH_V2.Models
{
    [Table("Clientes")]
    public class Cliente : BaseModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        public double Saldo { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cep { get; set; }

        public string Logradouro { get; set; }
        public string Uf { get; set; }
        public string Localidade { get; set;}

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "CPF:")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Rg:")]
        public string Rg { get; set; }

        [Display(Name = "Foto Cpf:")]
        public string ImagemCpf { get; set; }

        [Display(Name = "Foto segurando documento:")]
        public string Selfie { get; set; }

        [Display(Name = "Foto Rg:")]
        public string ImagemRg { get; set; }

        public string Nivel { get;set;}

        [Display(Name = "Data de Nascimento:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public DateTime Nascimento { get; set; }
        
        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Senha { get; set; }

        [Display(Name = "Confirmar Senha:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string ConfirmarSenha { get; set; }

        [Display(Name = "Email:")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Digite um email válido!")]
        public string Email { get; set; }
    }
}