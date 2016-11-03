using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce1.Models;
using System.IO;

namespace Ecommerce1.Controllers {
    public class AdminController : Controller {
        private dbEntities11 db = new dbEntities11();

        // GET: Admin
        public ActionResult Index() {
            return View();
        }

        public ActionResult login() {
            return View();
        }

        public ActionResult IndexProduct() {
            var produto = db.Produto.Include(p => p.Categoria);
            return View(produto.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult DetailsProduct(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null) {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Admin/Create
        public ActionResult CreateProduct() {
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nome");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct([Bind(Include = "idProduto,nome,descricao,preco,idCategoria,quantidade,foto")] Produto produto, HttpPostedFileBase files) {
            if (ModelState.IsValid) {
                db.Produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("IndexProduct");
            }

            string path = Path.Combine(Server.MapPath("~/Content/teste/"), files.FileName);
            files.SaveAs(path);            


            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nome", produto.idCategoria);
            return View(produto);
        }

        // GET: Admin/Edit/5
        public ActionResult EditProduct(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null) {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nome", produto.idCategoria);
            return View(produto);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct([Bind(Include = "idProduto,nome,descricao,preco,idCategoria,quantidade,foto")] Produto produto) {
            if (ModelState.IsValid) {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexProduct");
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nome", produto.idCategoria);
            return View(produto);
        }

        // GET: Admin/Delete/5
        public ActionResult DeleteProduct(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null) {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedProduct(int id) {
            Produto produto = db.Produto.Find(id);
            db.Produto.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("IndexProduct");
        }


        public ActionResult IndexCategory() {
            return View(db.Categoria.ToList());
        }

        // GET: Categorias/Details/5
        public ActionResult DetailsCategory(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categoria.Find(id);
            if (categoria == null) {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categorias/Create
        public ActionResult CreateCategory() {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory([Bind(Include = "idCategoria,nome")] Categoria categoria) {
            if (ModelState.IsValid) {
                db.Categoria.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("IndexCategory");
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult EditCategory(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categoria.Find(id);
            if (categoria == null) {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory([Bind(Include = "idCategoria,nome")] Categoria categoria) {
            if (ModelState.IsValid) {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexCategory");
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult DeleteCategory(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categoria.Find(id);
            if (categoria == null) {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedCategory(int id) {
            Categoria categoria = db.Categoria.Find(id);
            db.Categoria.Remove(categoria);
            db.SaveChanges();
            return RedirectToAction("IndexCategory");
        }



        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
