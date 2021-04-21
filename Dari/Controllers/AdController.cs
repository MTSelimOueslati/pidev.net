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
    public class AdController : Controller
    {

        HttpClient httpClient;
        string baseAddress;

        public AdController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/ad/";

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = 

        }
        [HttpPost]
        public ActionResult CreateAd(Ad ad)
        {
            var postTask = httpClient.PostAsJsonAsync<Ad>(baseAddress + "add", ad);
            postTask.Wait();

            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionAd");
            }
            return View();
        }
        // GET: Post/Create
        public ActionResult CreateAd()
        {
            return View();
        }
        // GET: Ad
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ad/Create
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

        // GET: Ad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ad/Edit/5
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

        // GET: Ad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ad/Delete/5
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
