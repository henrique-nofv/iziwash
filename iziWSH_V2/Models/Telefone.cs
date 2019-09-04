using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iziWSH_V2.Models
{
    [Table("Telefones")]
    public class Telefone : BaseModel
    {

       public Telefone()
        {
            Cliente = new Cliente();
        }

        public Cliente Cliente { get; set; }
        string Tipo { get; set; }
        string NumTelefone { get; set; }
    }
}
