using iziWSH_V2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iziWSH_V2.DAL
{
    public class ClienteDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static List<Cliente> RetornarClientes()
        {
            return ctx.Clientes.ToList();
        }

        public static bool CadastrarCliente(Cliente c)
        {
            if (BuscarClientePorCpf(c) == null)
            {
                c.Nivel = "1";
                ctx.Clientes.Add(c);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Cliente BuscarClientePorCpf(Cliente c)
        {
            return ctx.Clientes.FirstOrDefault(x => x.Cpf.Equals(c.Cpf));
        }

        public static Cliente BuscarDadosClientePorEmail(string Email)
        {
            return ctx.Clientes.FirstOrDefault(x => x.Email.Equals(Email));
        }

        public static Cliente BuscarClientePorEmail(Cliente c)
        {
            return ctx.Clientes.FirstOrDefault(x => x.Email.Equals(c.Email));
        }


        public static void ExcluirCliente(int id)
        {
            ctx.Clientes.Remove(BuscarClientePorId(id));
            ctx.SaveChanges();
        }

        public static List<Cliente> BuscarPrestadorPendente()
        {
            return ctx.Clientes.
                Where(x => x.Nivel.Equals("2")).ToList();
        }

       

        public static void AlterarCliente(Cliente c)
        {   
            ctx.Entry(c).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static Cliente BuscarClientePorId(int? id)
        {
            return ctx.Clientes.Find(id);
        }

    }
}