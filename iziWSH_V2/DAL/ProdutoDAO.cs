using iziWSH_V2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iziWSH_V2.DAL
{
    public class ProdutoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static List<Produto> RetornarProdutos()
        {
            return ctx.Produtos.ToList();
        }

        public static bool CadastrarProduto(Produto produto)
        {
            if (BuscarProdutoPorNome(produto) == null)
            {
                ctx.Produtos.Add(produto);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        

        public static Produto BuscarProdutoPorNome(Produto produto)
        {
            return ctx.Produtos.
                FirstOrDefault(x => x.Nome.Equals(produto.Nome));
        }

        public static Produto BuscarProdutoPorId(int id)
        {
            return ctx.Produtos.Find(id);
        }

        public static void RemoverProduto(int id)
        {
            ctx.Produtos.Remove(BuscarProdutoPorId(id));
            ctx.SaveChanges();
        }

        public static void AlterarProduto(Produto produto)
        {
            Produto imagem = new Models.Produto();
            imagem = BuscarProdutoPorId(produto.ProdutoId);
            ctx.Produtos.Remove(BuscarProdutoPorId(produto.ProdutoId));
            ctx.SaveChanges();

            produto.Imagem = imagem.Imagem;
            CadastrarProduto(produto);
            
            // ctx.Entry(produto).State = EntityState.Modified;
            // ctx.SaveChanges();
        }
    }
}