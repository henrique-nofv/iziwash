using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iziWSH_V2.Models
{
    [Table("Vendas")]
    public class Venda
    {
        [Key]
        public int VendaId { get; set; }


        [Display(Name = "CEP")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cep { get; set; }

        public string Logradouro { get; set; }
        public string Uf { get; set; }
        public string Localidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Numero do Cartão")]
        public int NumeroCartao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome Cartão")]
        public string NomeCartao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Validade")]
        public string Validade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Código de Segurança")]
        public int CodSeguranca { get; set; }

        public double Valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Numero do Local")]
        public string NumeroRua { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Modelo do Carro")]
        public string ModeloCarro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Placa do Carro")]
        public string PlacaCarro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Marca do Carro")]
        public string MarcaCarro { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        public string CarrinhoId { get; set; }
        public string StatusVenda { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Data de Realização")]
        public DateTime Data { get; set; }
        public string NomeServico { get; set; }
        public Cliente cliente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Horario de Realização")]
        public string Hora { get; set; }
        public List<ItemVenda> Itens { get; set; }
    }
}