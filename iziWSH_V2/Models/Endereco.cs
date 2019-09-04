using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iziWSH_V2.Models
{
    public class Endereco
    {
        [Display(Name = "CEP")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cep { get; set; }

        public string Logradouro { get; set; }
        public string Uf { get; set; }
        public string Localidade { get; set; }

    }
}