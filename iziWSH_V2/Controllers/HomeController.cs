using iziWSH_V2.DAL;
using Newtonsoft.Json;
using iziWSH_V2.Models;
using iziWSH_V2.Utils;
using System;
using System.Web.Mvc;
using System.Net;
using System.Text;

namespace iziWSH_V2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaginaErro()
        {
            return View();
        }

        public ActionResult ProdutosVenda()
        {
            return View(ProdutoDAO.RetornarProdutos());
        }

        public ActionResult AdicionarAoCarrinho(int id)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            ItemVenda itemVenda = new ItemVenda
            {
                Produto = produto,
                Quantidade = 1,
                Preco = produto.Preco,
                Data = DateTime.Now,
                CarrinhoId = Sessao.RetornarCarrinhoId()
            };
            ItemVendaDAO.CadastrarItemVenda(itemVenda);
            return RedirectToAction("CarrinhoCompras");
        }


        [HttpPost]
        public ActionResult BuscarCep(Venda venda)
        {
            try
            {
                //Url da requisição
                string url = "https://viacep.com.br/ws/" + venda.Cep + "/json/";
                //Objeto que permite fazer o download do JSON
                WebClient client = new WebClient();
                string resultado = client.DownloadString(url);
                //Converter a string para UTF-8
                byte[] bytes = Encoding.Default.GetBytes(resultado);
                resultado = Encoding.UTF8.GetString(bytes);
                //Converter o JSON para o objeto
                venda = JsonConvert.DeserializeObject<Venda>(resultado);
                TempData["Cliente"] = venda;
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "CEP inválido!";
            }

            return RedirectToAction("FinalizarCompra", "Home");
        }


        public ActionResult CarrinhoCompras()
        {
            ViewBag.Total = ItemVendaDAO.RetornarTotalCarrinho();
            return View(ItemVendaDAO.
                BuscarItensVendaPorCarrinhoId());
        }

        public ActionResult FinalizarCompra()
        {
            Endereco endereco = new Endereco();
            if (TempData["Mensagem"] != null)
            {
                ModelState.AddModelError("", TempData["Mensagem"].ToString());
            }
            if (TempData["Cliente"] != null)
            {
                ViewBag.Itens = ItemVendaDAO.BuscarItensVendaPorCarrinhoId();
                
                return View(TempData["Cliente"]);
            }
            ViewBag.Itens = ItemVendaDAO.BuscarItensVendaPorCarrinhoId();
            return View();
        }

        [HttpPost]
        public ActionResult FinalizarCompra(Venda venda)
        {
            ItemVenda iv = new ItemVenda();

            venda.Email = Request.Cookies["Email"].Value;
            venda.StatusVenda = "Aguardando Confirmação de Pagamento";
            venda.Valor = Convert.ToDouble(Request.Cookies["Valor"].Value);
            venda.CarrinhoId= Sessao.RetornarCarrinhoId();
            venda.Itens = ItemVendaDAO.BuscarItensVendaPorCarrinhoId();

            string carrinhoid;

            carrinhoid = venda.CarrinhoId;
            iv = ItemVendaDAO.BuscarCarrinhoPorId(carrinhoid);
           
               venda.NomeServico = iv.Produto.Nome;
            

            Sessao.ZerarSessaoCarrinho();
            VendaDAO.CadastrarVenda(venda);
            return RedirectToAction("Index", "Home");
        }
    }
}