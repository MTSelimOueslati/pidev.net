using Dari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Dari.Controllers
{
    public class OfferController : Controller
    {
        HttpClient httpClient;
        string baseAddress;

        public OfferController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/offer/";

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = 

        }

        // GET: Offer
        public ActionResult GestionOffer()
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "getAll").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.offers = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.offer>>().Result;
            }
            else
            {
                ViewBag.offers = "erreur";
            }
            return View();
        }
        // Get: OfferTri
        public ActionResult TriOffer()
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "getTri").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.offers = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.offer>>().Result;
            }
            else
            {
                ViewBag.offers = "erreur";
            }
            return View();
        }
        // Get: OfferStat
        public ActionResult OfferStat()
        {
            
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "stat").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.offers = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.offer>>().Result;

            }
            else
            {
                ViewBag.offers = "erreur";
            }
            return View();
        }
        // GET: Offer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }
        // POST: Offer/Details/5
        [HttpPost]
        public ActionResult Details(int id, FormCollection collection)
        {
            {
                //HTTP POST
                var putTask = httpClient.GetAsync(baseAddress + "genrateAndDownloadQRCode/" + id.ToString());
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("GestionOffer");
                }
                System.Diagnostics.Debug.WriteLine("entered here" + result);
                return View();
            }
        }
       
        
        // POST: Offer/QRg/5
        
        /*public ActionResult QRg(int id)
        {
            {
                var _AccessToken = Session["AccessToken"];
                httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "genrateAndDownloadQRCode/" + id.ToString()).Result;

                
                if (httpResponseMessage.IsSuccessStatusCode)
                {

                    return RedirectToAction("GestionOffer");
                }
                System.Diagnostics.Debug.WriteLine("entered here" + httpResponseMessage);
                return View();
            }
        }*/
        // GET: Offre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offre/Create
       /* [HttpPost]
        public ActionResult(ForCreatemCollection collection)
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
       */
        // GET: Offre/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Offre/Edit/5
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

        // GET: Offer/Delete/5
        public ActionResult DeleteOffer(int id)
        {
            return View();
        }

        // POST: Offer/Delete/5
        [HttpPost]
        public ActionResult DeleteOffer(int id, FormCollection collection)
        {
            //HTTP POST
            var putTask = httpClient.DeleteAsync(baseAddress + "delete/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionOffer");
            }
            System.Diagnostics.Debug.WriteLine("entered here" + result);
            return View();
        }
    }
}
