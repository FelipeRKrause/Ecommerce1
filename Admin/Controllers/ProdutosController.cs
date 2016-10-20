using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admin.Models;

namespace Admin.Controllers
{
    public class ProdutosController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: Produtos
        public ActionResult IndexProduct()
        {
            var produto = db.Produto.Include(p => p.Categoria);
            return View(produto.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult DetailsProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult CreateProduct()
        {
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct([Bind(Include = "idProduto,nome,descricao,preco,idCategoria,quantidade,foto,ativo,promo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("IndexProduct");
            }

            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nome", produto.idCategoria);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nome", produto.idCategoria);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct([Bind(Include = "idProduto,nome,descricao,preco,idCategoria,quantidade,foto,ativo,promo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexProduct");
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nome", produto.idCategoria);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedProduct(int id)
        {
            Produto produto = db.Produto.Find(id);
            db.Produto.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("IndexProduct");
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
