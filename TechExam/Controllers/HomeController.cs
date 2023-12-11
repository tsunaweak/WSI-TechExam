using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechExam.Models;
using TechExam.Types;

namespace TechExam.Controllers
{
    public class HomeController : Controller
    {
        private Product product;
        private Cart cart;
        private Transaction transaction;

        public HomeController() {
            this.product = new Product();
            this.cart = new Cart();
            this.transaction = new Transaction();
        }



        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult ShowProduct(int Id) {
            DataTable dt = this.product.Find(Id);
            string JSONResult = JsonConvert.SerializeObject(dt);

            return Json(JSONResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ShowCarts()
        {
            DataTable dt = this.cart.FindAll();
            string JSONResult = JsonConvert.SerializeObject(dt);
            string totalAmount = this.cart.getTotalAmount();
            return Json(new { data = JSONResult, totalAmount= totalAmount }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveCart(int product_id, int qty) {
            this.cart.Save(qty, product_id);
            return Json("Cart details has been saved.");
        }

       

        [HttpPost]
        public JsonResult DeleteCart(int cart_id)
        {
            this.cart.Remove(cart_id);
            return Json("Cart details has been removed.");
        }



        [HttpPost]
        public JsonResult SaveTransaction(int total_amount, int cash_amount, int change_amount, int[] cart_ids) {
            this.transaction.Save(total_amount, cash_amount, change_amount, cart_ids);
            return Json("Transaction details has been saved.");
        }
    }
}