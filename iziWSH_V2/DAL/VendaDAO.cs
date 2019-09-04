using iziWSH_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iziWSH_V2.DAL
{
    public class VendaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static void CadastrarVenda(Venda venda)
        {
            ctx.Vendas.Add(venda);
            ctx.SaveChanges();
        }

        public static List<Venda> BuscarVendaPorNome()
        {
            return ctx.Vendas.  
                Where(x => x.StatusVenda.Equals("Aguardando Prestador")).ToList();
        }

        public static Venda BuscarVendaPorId(int? id)
        {
            return ctx.Vendas.Find(id);
        }

        public static void AlterarVenda(Venda v)
        {
            ctx.Entry(v).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public static List<Venda> BuscarMeusServicos(string Email)
        {
            return ctx.Vendas.
                Where(x => x.Email.Equals(Email)).ToList();
        }

        public static List<Venda> BuscarMeusServicosAFazer(string Nome)
        {
            return ctx.Vendas.
                Where(x => x.cliente.Nome.Equals(Nome)).ToList();
        }

        public static List<Venda> BuscarPagamentosPendentes()
        {
            return ctx.Vendas.
                Where(x => x.StatusVenda.Equals("Aguardando Confirmação de Pagamento")).ToList();
        }

        public static Venda BuscarCarrinhoPorId(string carrinhoId)
        {
            return ctx.Vendas.FirstOrDefault(x => x.CarrinhoId.Equals(carrinhoId));
        }

    }
}