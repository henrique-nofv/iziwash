using iziWSH_V2.DAL;
using iziWSH_V2.Models;
using iziWSH_V2.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace iziWSH_V2.Controllers
{
    public class ClienteController : Controller
    {
        private Context db = new Context();

        

        public ActionResult CadastrarSolicitante()
        {
            /*
            if (TempData["Mensagem"] != null)
            {
                ModelState.AddModelError("", TempData["Mensagem"].ToString());
            }
            return View(TempData["Cliente"]);*/
               if (ModelState.IsValid)
               {

                   if (Request.Cookies["Email"].Value == "")
                   {
                       if (TempData["Mensagem"] != null)
                       {
                           ModelState.AddModelError("", TempData["Mensagem"].ToString());
                       }
                       ViewBag.Data = DateTime.Now;
                    if (TempData["Cliente"] != null) { 
                       return View(TempData["Cliente"]);
                    }
                }
                   else
                   {
                       return RedirectToAction("Index", "Home");
                   }
               }
               return View();
        }

        public ActionResult AprovarPagamento()
        {
            return View(VendaDAO.BuscarPagamentosPendentes());
        }

        public ActionResult AprovarPagamentoCartao(int? id)
        {
            Venda v = new Venda();
            v = VendaDAO.BuscarVendaPorId(id);
            v.StatusVenda = "Aguardando Prestador";
            VendaDAO.AlterarVenda(v);
            return View();
        }

        public ActionResult ConcluirServico(int? id)
        {
            string Email;
            Cliente c = new Cliente();
            string emailAdmin;

            emailAdmin = "admin@admin.com";
            Email = Request.Cookies["Email"].Value;
            c = ClienteDAO.BuscarDadosClientePorEmail(Email);

            Venda v = new Venda();
            v = VendaDAO.BuscarVendaPorId(id);

            if (v.Valor == 35)
            {
                c.Saldo = c.Saldo + 30;
                c = ClienteDAO.BuscarDadosClientePorEmail(emailAdmin);
                c.Saldo = c.Saldo + 5;
            }
            if (v.Valor == 45)
            {
                c.Saldo = c.Saldo + 40;
                c = ClienteDAO.BuscarDadosClientePorEmail(emailAdmin);
                c.Saldo = c.Saldo + 5;
            }

            ClienteDAO.AlterarCliente(c);
            v.StatusVenda = "Concluido.";
            VendaDAO.AlterarVenda(v);
            return View();
        }

        public ActionResult CancelarServico(int? id)
        {
            Venda v = new Venda();
            v = VendaDAO.BuscarVendaPorId(id);
            v.StatusVenda = "Serviço Cancelado.";
            VendaDAO.AlterarVenda(v);
            return View();
        }

        public ActionResult Saldo()
        {
            Cliente c = new Cliente();
            string Email;
                
            Email = Request.Cookies["Email"].Value;
            c = ClienteDAO.BuscarDadosClientePorEmail(Email);

            return View(c);
        }

        public ActionResult RejeitarPagamentoCartao(int? id)
        {
            Venda v = new Venda();
            v = VendaDAO.BuscarVendaPorId(id);
            v.StatusVenda = "Pagamento Rejeitado!";
            VendaDAO.AlterarVenda(v);
            return View();
        }

        public ActionResult MeusServicos()
        {
            List<Venda> v = new List<Venda>();
            string email;
            email = Request.Cookies["Email"].Value;
            
            v = VendaDAO.BuscarMeusServicos(email);

            return View(v);
        }

        public ActionResult MeusServicosAFazer()
        {
            List<Venda> v = new List<Venda>();
            Cliente c = new Models.Cliente();
            
            string email;
            email = Request.Cookies["Email"].Value;
            c = ClienteDAO.BuscarDadosClientePorEmail(email);

            v = VendaDAO.BuscarMeusServicosAFazer(c.Nome);
            
            
            return View(v);
        }

        [HttpPost]
        public ActionResult Login(Cliente cliente, bool EstaConectado)
        {
            if (Request.Cookies["Email"].Value != "")
            {
                ViewBag.Data = DateTime.Now;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                cliente = db.Clientes.FirstOrDefault(x =>
                    x.Email.Equals(cliente.Email) &&
                    x.Senha.Equals(cliente.Senha));
                if (cliente != null)
                {
                    //Autenticar o usuário no sistema
                    FormsAuthentication.SetAuthCookie(cliente.Email, EstaConectado);
                    Response.Cookies["Email"].Value = cliente.Email;
                    Response.Cookies["Nivel"].Value = cliente.Nivel;
                    return RedirectToAction("Index", "Produto");
                }
                ModelState.AddModelError("", "E-mail ou senha inválidos!");
                return View();
            }
        }

        public ActionResult Login()
        {
            if (Request.Cookies["Email"].Value != "")
            {
                ViewBag.Data = DateTime.Now;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

    

        public ActionResult AprovarColaborador(int id)
        {
            Cliente c = new Cliente();
            c =  ClienteDAO.BuscarClientePorId(id);
            c.Nivel = "3";
            ClienteDAO.AlterarCliente(c);
            return View(); ;
        }

        public ActionResult RejeitarColaborador(int id)
        {
            Cliente c = new Cliente();
            c = ClienteDAO.BuscarClientePorId(id);
            c.Nivel = "1";
            ClienteDAO.AlterarCliente(c);
            return View(); ;
        }

        [HttpPost]
        public ActionResult BuscarCep(Cliente cliente)
        {
            try
            {
                //Url da requisição
                string url = "https://viacep.com.br/ws/" + cliente.Cep + "/json/";
                //Objeto que permite fazer o download do JSON
                WebClient client = new WebClient();
                string resultado = client.DownloadString(url);
                //Converter a string para UTF-8
                byte[] bytes = Encoding.Default.GetBytes(resultado);
                resultado = Encoding.UTF8.GetString(bytes);
                //Converter o JSON para o objeto
                cliente = JsonConvert.DeserializeObject<Cliente>(resultado);
                TempData["Cliente"] = cliente;
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "CEP inválido!";
            }

            return RedirectToAction("CadastrarSolicitante", "Cliente");
        }

        public ActionResult ListarSolicitante()
        {

            if (Request.Cookies["Email"].Value != "" && Request.Cookies["Nivel"].Value.Equals("99"))
            {
                ViewBag.Data = DateTime.Now;
                return View(ClienteDAO.RetornarClientes());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult RealizarServico()
        {
            return View(VendaDAO.BuscarVendaPorNome());
        }

        public ActionResult AprovarColaboradores()
        {

            if (Request.Cookies["Email"].Value != "" && Request.Cookies["Nivel"].Value.Equals("99"))
            {
                ViewBag.Data = DateTime.Now;
                return View(ClienteDAO.BuscarPrestadorPendente());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Logout()
        {
            Response.Cookies["Email"].Value = null;
            Response.Cookies["Nivel"].Value = "0";
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CadastrarPrestador(Cliente c)
        {
            c.Email = Request.Cookies["Email"].Value;
            c = db.Clientes.FirstOrDefault(x =>
                x.Email.Equals(c.Email));
            return View(c);
        }


        public ActionResult RealizaServico(int id)
        {
            Venda v = new Venda();
            v = VendaDAO.BuscarVendaPorId(id);
            string email;

            v.StatusVenda = "Aguardando Lavagem";
            email = Request.Cookies["Email"].Value;
            v.cliente = ClienteDAO.BuscarDadosClientePorEmail(email);

            VendaDAO.AlterarVenda(v);
            
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarPrestador(Cliente cliente,
            HttpPostedFileBase fupImagem, HttpPostedFileBase fupImagem2, HttpPostedFileBase fupImagem3)
        {
            cliente = ClienteDAO.BuscarClientePorId(cliente.Id);
            if (fupImagem != null)
            {
                string nomeImagem = Path.GetFileName(fupImagem.FileName);
                string caminho = Path.Combine(Server.MapPath("~/Imagens"), nomeImagem);
                fupImagem.SaveAs(caminho);
                cliente.ImagemCpf = nomeImagem;
                if (fupImagem2 != null)
                {
                    string nomeImagem2 = Path.GetFileName(fupImagem2.FileName);
                    string caminho2 = Path.Combine(Server.MapPath("~/Imagens"), nomeImagem2);
                    fupImagem2.SaveAs(caminho2);
                    cliente.ImagemRg = nomeImagem2;
                    cliente.Nivel = "2";
                    if (fupImagem3 != null)
                    {
                        string nomeImagem3 = Path.GetFileName(fupImagem3.FileName);
                        string caminho3 = Path.Combine(Server.MapPath("~/Imagens"), nomeImagem3);
                        fupImagem3.SaveAs(caminho3);
                        cliente.Selfie = nomeImagem3;
                        cliente.Nivel = "2";
                        ClienteDAO.AlterarCliente(cliente);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        cliente.ImagemCpf = "semimagem.png";
                    }
                }
                else
                {
                    cliente.ImagemRg = "semimagem.png";
                }
            }
            else
            {
                cliente.ImagemCpf = "semimagem.png";
            }


            return View(cliente);

        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarSolicitante(Cliente c)
        {

            if (ModelState.IsValid)
            {

                if (c.Senha == c.ConfirmarSenha)
                {
                    if (ValidarCpf.Cpf(c.Cpf))
                    {
                        if (ClienteDAO.CadastrarCliente(c))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Não é possível adicionar um cliente com mesmo cpf!");
                            return View(c);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cpf inválido!");
                        return View(c);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Senhas não iguais!");
                    return View(c);
                }


            }
            else
            {
                return View(c);
            }

        }

    }
}
