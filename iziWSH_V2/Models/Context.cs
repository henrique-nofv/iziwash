using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iziWSH_V2.Models
{

    public class Context : DbContext
    {
        public Context() : base("DbIziWSH")
        {

        }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
    }
}