using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dari.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.StripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            return View();
        }

        [HttpPost]
        public ActionResult Charge(string stripeToken, string stripeEmail)
        {
            Stripe.StripeConfiguration.SetApiKey("pk_test_51ITYUZKuxtPIEeD5qxXEmosvcdrfrhZNcUJzOb6DzZ5WxX6j5a3KaJ1BzTEvyfovHw7La921Z8gAkm1w7haPXIYb00pl5lcmuV");
            Stripe.StripeConfiguration.ApiKey = "sk_test_51ITYUZKuxtPIEeD5lsPmKh2sG7jhzhhOpuBjXgXg4PL8cdjL79dL038v5SXcR32Ro9yIRxpfX6KfPQrQSxmR1h1p00xID5MdR4";


            var myCharge = new Stripe.ChargeCreateOptions();
            // always set these properties
            myCharge.Amount = 500;
            myCharge.Currency = "USD";
            myCharge.ReceiptEmail = stripeEmail;
            myCharge.Description = "Sample Charge";
            myCharge.Source = stripeToken;
            myCharge.Capture = true;
            var chargeService = new Stripe.ChargeService();
            Charge stripeCharge = chargeService.Create(myCharge);
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
