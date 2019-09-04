using iziWSH_V2.DAL;
using iziWSH_V2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iziWSH_V2.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        // GET: Produto
        public ActionResult Index()
        {
            if (Request.Cookies["Email"].Value != "" && Request.Cookies["Nivel"].Value.Equals("99"))
            {
                ViewBag.Data = DateTime.Now;

                //Verificando se o usuário está autenticado
                //if (Request.IsAuthenticated)
                //{
                //    ViewBag.Usuario = User.Identity.Name;
                //}
                //else
                //{
                //    ViewBag.Usuario = "Não Autenticado";
                //}

                return View(ProdutoDAO.RetornarProdutos());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
        public ActionResult Detalhes(string CarrinhoId)
        {
            Venda v = new Venda();
            ItemVenda iv = new ItemVenda();
            Cliente c = new Cliente();

            

            v = VendaDAO.BuscarCarrinhoPorId(CarrinhoId);
            iv = ItemVendaDAO.BuscarCarrinhoPorId(CarrinhoId);
            c = ClienteDAO.BuscarDadosClientePorEmail(v.Email);

            ViewData["IdVenda"] = v.VendaId;
            ViewData["StatusServico"] = v.StatusVenda;
            ViewData["NomeProduto"] = iv.Produto.Nome;
            ViewData["ImagemProduto"] = iv.Produto.Imagem;
            ViewData["Preco"] = iv.Produto.Preco;
            ViewData["Cep"] = v.Cep;
            ViewData["Rua"] = v.Logradouro;
            ViewData["Numero"] = v.NumeroRua;
            ViewData["PlacaCarro"] = v.PlacaCarro;
            ViewData["MarcaCarro"] = v.MarcaCarro;
            ViewData["NomeCliente"] = c.Nome;

            

            return View(iv);
        }

        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto, int? Categorias,
            HttpPostedFileBase fupImagem)
        {
            

            if (ModelState.IsValid)
            {
                    if (fupImagem != null)
                    {
                        string nomeImagem = Path.GetFileName(fupImagem.FileName);
                        string caminho = Path.Combine(Server.MapPath("~/Imagens"), nomeImagem);
                        fupImagem.SaveAs(caminho);
                        produto.Imagem = nomeImagem;
                    }
                    else
                    {
                        produto.Imagem = "semimagem.png";
                    }
                    
                    if (ProdutoDAO.CadastrarProduto(produto))
                    {
                        return RedirectToAction("Index", "Produto");
                    }
                    else
                    {
                        ModelState.AddModelError("",
                            "Não é possível adicionar um produto com o mesmo nome!");
                        return View();
                    }
                }
                
            
            return View(produto);
        }

        public ActionResult RemoverProduto(int id)
        {
            ProdutoDAO.RemoverProduto(id);
            return RedirectToAction("Index", "Produto");
        }

        public ActionResult AlterarProduto(int id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }

        [HttpPost]
        public ActionResult AlterarProduto(Produto produto)
        {

            ProdutoDAO.AlterarProduto(produto);
            return RedirectToAction("Index", "Produto");
        }
    }
}