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
    public class ClientesController : Controller {
        private dbEntities10 db = new dbEntities10();

        private IClienteRepository iClienteRepository = new ClienteRepository();

        [HttpGet]
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
                return View("Create");

            }
        }


        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        public ActionResult MyAccount() {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Cliente cliente) {
            iClienteRepository.create(cliente);

            return RedirectToAction("Create", "Clientes");
        }



        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
