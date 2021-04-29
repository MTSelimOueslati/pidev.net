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
    public class BankController : Controller
    {


        HttpClient httpClient;
        string baseAddress;

        public BankController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/bank/";

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = 

        }




        // GET: Bank
        public ActionResult GestionBank()
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "getAll").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.banks = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.bank>>().Result;
            }
            else
            {
                ViewBag.banks = "erreur";
            }
            return View();
        }


        // GET: Bank/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bank/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bank/Create
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

        // GET: Bank/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bank/Edit/5
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

        // GET: Bank/Delete/5
        public ActionResult DeleteBank(int id)
        {
            return View();
        }

        // POST: Bank/Delete/5
        [HttpPost]
        public ActionResult DeleteBank(int id, FormCollection collection)
        {
            //HTTP POST
            var putTask = httpClient.DeleteAsync(baseAddress + "delete/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionBank");
            }
            System.Diagnostics.Debug.WriteLine("entered here" + result);
            return View();
        }
    }
}

