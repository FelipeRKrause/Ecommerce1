using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce1.Models;
using Ecommerce1.Repository;

namespace Ecommerce1.Controllers {
    public class HomeController : Controller {

        private ICategoriaRepository iCategoriaRepository = new CategoriaRepository();
        private IProdutoRepository iProdutoRepository = new ProdutoRepository();
        private IClienteRepository iClienteRepository = new ClienteRepository();
        private dbEntities10 db = new dbEntities10();



        [Route("", Name ="Index")]
        public ActionResult Index() {

            var produto = db.Produto.Include(p => p.Categoria);
            return View(produto.ToList());

        }


        [Route("Categoria/{id}", Name = "Categoria")]
        public ActionResult Categoria(int id) {

            var categoria = iCategoriaRepository.find(id);
            ViewBag.categoria = categoria;
            ViewBag.produtos = categoria.Produto.ToList();
            return View();

        }

        [Route("Detalhe/{id}", Name ="Detalhe")]
        public ActionResult Detalhe(int id) {

            ViewBag.produto = iProdutoRepository.find(id);
            return View();

        }


        [Route("Contato", Name ="Contato")]
        public ActionResult Contato() {

            return View();

        }

        [HttpGet]
        [Route("Login", Name ="Login")]
        public ActionResult Login() {

            return View();

        }

        [HttpPost]        
        public ActionResult Login(Cliente cliente) {

            Cliente cli = iClienteRepository.login(cliente.email, cliente.senha);
            if (cli == null) {
                ViewBag.error = "Email ou Senha inválido";
                return View("Login");
            } else {
                Session["email"] = cli.email;
                Session["senha"] = cli.senha;
                 return RedirectToAction("Index");

            }
        }


        [HttpGet]
        [Route("Cadastro", Name ="Cadastro")]
        public ActionResult Cadastro() {

            return View();

        }


        [HttpPost]
        public ActionResult Cadastro(Cliente cliente) {

            iClienteRepository.create(cliente);
            return RedirectToAction("Cadastro", "Home");

        }

        [Route("Manager", Name ="Manager")]
        public ActionResult Manager() {

            return View();

        }

        [Route("Carrinho", Name ="Carrinho")]
        public ActionResult Cart() {

            return View();
        }

        public ActionResult Buy(int id) {

            if (Session["cart"] == null) {

                List<Item> cart = new List<Item>();
                cart.Add(new Item() {
                    produto = iProdutoRepository.find(id),
                    quantidade = 1


                });
                Session["cart"] = cart;

            } else {

                List<Item> cart = (List<Item>)Session["cart"];
                cart.Add(new Item() {
                    produto = iProdutoRepository.find(id),
                    quantidade = 1

                });
                Session["cart"] = cart;


            }

            return View("Cart");
        }



        protected override void Dispose(bool disposing) {

            if (disposing) {
                db.Dispose();
            }

            base.Dispose(disposing);

        }


    }
}