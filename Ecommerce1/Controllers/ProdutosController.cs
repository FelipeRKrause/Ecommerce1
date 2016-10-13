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

namespace Ecommerce1.Controllers
{
    public class ProdutosController : Controller
    {
        private ICategoriaRepository iCategoriaRepository = new CategoriaRepository();
        private IProdutoRepository iProdutoRepository = new ProdutoRepository();
        private dbEntities1 db = new dbEntities1();


        public ActionResult Index()
        {

            var produto = db.Produto.Include(p => p.Categoria);
            return View(produto.ToList());
        }

        public ActionResult Contato()
        {


            return View();
        }

        public ActionResult Carrinho()
        {


            return View();
        }

        public ActionResult Categorias(int id)
        {
            var categoria = iCategoriaRepository.find(id);
            ViewBag.categoria = categoria;
            ViewBag.produtos = categoria.Produto.ToList();

            return View();
        }

        public ActionResult Detalhes(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.produto = iProdutoRepository.find(id);
            return View();
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
