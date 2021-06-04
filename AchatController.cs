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
    public class AchatController : Controller
    {

        HttpClient httpClient;
        string baseAddress;

        public AchatController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/";

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = 

        }

        // GET: Achat
        public ActionResult GestionAchat()
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "achat/getAll").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.achats = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.Achat>>().Result;
            }
            else
            {
                ViewBag.achats = "erreur";
            }
            return View();
        }

        // GET: Achat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult DeleteAchat(int id, FormCollection collection)
        {

            //HTTP POST
            var putTask = httpClient.DeleteAsync(baseAddress + "achat/delete/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionAchat");
            }
            System.Diagnostics.Debug.WriteLine("entered here" + result);
            return View();
        }
        // GET: Achat/Create
        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        public ActionResult AddAchat(Achat a)
        {
            var postTask = httpClient.PostAsJsonAsync<Achat>(baseAddress + "Sign", a);
            postTask.Wait();

            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionAchat");
            }
            return View();
        }
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

        // GET: Achat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Achat/Edit/5
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

        // GET: Achat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Achat/Delete/5
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
