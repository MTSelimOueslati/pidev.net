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
    public class ContractController : Controller
    {
        HttpClient httpClient;
        string baseAddress;

        public ContractController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/contract/";

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = 

        }


        // GET: Insurance
        public ActionResult GestionContract()
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "show").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.contracts = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.Contract>>().Result;
            }
            else
            {
                ViewBag.contracts = "erreur";
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateContract(Contract contract)
        {
            var postTask = httpClient.PostAsJsonAsync<Contract>(baseAddress + "add/1", contract);
            postTask.Wait();

            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionContract");
            }
            return View();
        }
        // GET: Post/Create
        public ActionResult CreateContract()
        {
            return View();
        }
        // GET: Contract
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contract/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contract/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contract/Create
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

        // GET: Contract/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contract/Edit/5
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

        // GET: Contract/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contract/Delete/5
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
