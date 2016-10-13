using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce1.Repository;
using Ecommerce1.Models;

namespace Ecommerce1.Controllers {
    public class CartController : Controller {

        private IProdutoRepository iProdutoRepository = new ProdutoRepository();

        public ActionResult Index() {
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
            
            return View("Index");
        }
    }
}