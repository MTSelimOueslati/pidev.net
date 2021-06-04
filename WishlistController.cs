using Dari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;


namespace Dari.Controllers
{
    public class WishlistController : Controller
    {

        HttpClient httpClient;
        string baseAddress;

        public WishlistController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/wishlist/";

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = 

        }



        public ActionResult EditWishlist(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditWishlist(int idw,Wishlist w)
        {
            var putTask = httpClient.PutAsJsonAsync<Wishlist>(baseAddress + "update/" + idw.ToString(), w);

            putTask.Wait();
            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {
                // TODO: Add update logic here

                return RedirectToAction("GestionWishlist");
            }
            
            return View();
            
        }

        public ActionResult DeleteWishlist(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteWishlist(int id, FormCollection collection)
        {

            //HTTP POST
            var putTask = httpClient.DeleteAsync(baseAddress + "delete/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionWishlist");
            }
            System.Diagnostics.Debug.WriteLine("entered here" + result);
            return View();
        }

        // GET: Wishlist
        public ActionResult GestionWishlist()
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "getAll").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.wishlists = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.Wishlist>>().Result;
            }
            else
            {
                ViewBag.wishlists = "erreur";
            }
            return View();
        }


        [HttpPost]
        public ActionResult CreateWishlist(Wishlist w)
        {
            var postTask = httpClient.PostAsJsonAsync<Wishlist>(baseAddress + "add", w);
            postTask.Wait();

            var result = postTask.Result;
            string accountSid = "AC128463e8006adf833ebbd776a1c421d4";
            string authToken = "37f0f023e984d4f74fb6801e306d9f57";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Ad ajouté dans le wishlist avec succés",
                from: new Twilio.Types.PhoneNumber("+16788537221"),
                to: new Twilio.Types.PhoneNumber("+21655374823")
            );

            Console.WriteLine(message.Sid);

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionWishlist");
            }
            return View();
        }
        // GET: Post/Create
        public ActionResult CreateWishlist()
        {
            return View();
        }
        // GET: Wishlist
        public ActionResult Index()
        {
            return View();
        }

        // GET: Wishlist/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Wishlist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wishlist/Create
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

        // GET: Wishlist/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Wishlist/Edit/5
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

        // GET: Wishlist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Wishlist/Delete/5
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

        [HttpPost]
        public ActionResult AddWishlist(Wishlist w)
        {
            var postTask = httpClient.PostAsJsonAsync<Wishlist>(baseAddress + "add/1", w);
            postTask.Wait();

            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionWishlist");
            }
            return View();
        }
        // GET: Post/Create
        public ActionResult AddWishlist()
        {
            return View();
        }
    }
}
