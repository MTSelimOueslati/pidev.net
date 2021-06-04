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
    public class DocumentsController : Controller
    {
        HttpClient httpClient;
        string baseAddress;

        public DocumentsController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/documents/";

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
            //var _AccessToken = 

        }

        [HttpPost]
        public ActionResult CreateDocuments(Documents documents)
        {
            var postTask = httpClient.PostAsJsonAsync<Documents>(baseAddress + "add", documents);
            postTask.Wait();

            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionDocuments");
            }
            return View();
        }
        // GET: Post/Create
        public ActionResult CreateDocuments()
        {
            return View();
        }
        // GET: Documents
        public ActionResult Index()
        {
            return View();
        }

        // GET: Documents/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Documents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
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

        // GET: Documents/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Documents/Edit/5
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

        // GET: Documents/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Documents/Delete/5
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
