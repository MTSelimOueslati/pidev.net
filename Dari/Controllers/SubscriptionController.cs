using Dari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Stripe.Infrastructure;

namespace Dari.Controllers
{
    public class SubscriptionController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        Stripe.StripeConfiguration.SetApiKey(“pk_test_FyPZYPyqf8jU6IdG2DONgudS”);  




        public SubscriptionController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/subscription/";

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = 

        }





        [HttpPost]
        public ActionResult ActivateSub(Subscription subscription)
        {
            var postTask = httpClient.PostAsJsonAsync<Subscription>(baseAddress + "ActivateSubscription/20", subscription);
            postTask.Wait();

            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }


        // GET: Insurance
        public ActionResult GestionSubscription()
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "findall").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.subscriptions = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.Subscription>>().Result;
            }
            else
            {
                ViewBag.subscriptions = "erreur";
            }
            return View();
        }
        // GET: Post/Create
        public ActionResult ActivateSub()
        {
            return View();
        }

        // GET: Subscription
        public ActionResult Index()
        {
            return View();
        }

        // GET: Subscription/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Subscription/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subscription/Create
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

        // GET: Subscription/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Subscription/Edit/5
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

        // GET: Subscription/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Subscription/Delete/5
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
