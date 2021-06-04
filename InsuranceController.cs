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
    public class InsuranceController : Controller
    {
        HttpClient httpClient;
        string baseAddress;

        public InsuranceController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/insurance/";

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = 

        }




        // GET: Insurance
        public ActionResult GestionInsurance()
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "findall").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.insurances = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.Insurance>>().Result;
            }
            else
            {
                ViewBag.insurances = "erreur";
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateInsurance(Insurance insurance)
        {
            var postTask = httpClient.PostAsJsonAsync<Insurance>(baseAddress + "add", insurance);
            postTask.Wait();

            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionInsurance");
            }
            return View();
        }
        // GET: Post/Create
        public ActionResult CreateInsurance()
        {
            return View();
        }

        public ActionResult DeleteInsurance(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteInsurance(int id, FormCollection collection)
        {

            //HTTP POST
            var putTask = httpClient.DeleteAsync(baseAddress + "delete/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionInsurance");
            }
            System.Diagnostics.Debug.WriteLine("entered here" + result);
            return View();
        }

        // GET: Insurance
        public ActionResult Index()
        {
            return View();
        }

        // GET: Insurance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Insurance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insurance/Create
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

        // GET: Insurance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Insurance/Edit/5
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

        // GET: Insurance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Insurance/Delete/5
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
