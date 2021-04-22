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
    public class UserController : Controller
    {
        HttpClient httpClient;
        string baseAddress;

        public UserController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/api/auth/";

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = 

        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            var postTask = httpClient.PostAsJsonAsync<User>(baseAddress + "signup", user);
            postTask.Wait();

            var result = postTask.Result;
             
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Post/Create
        public ActionResult CreateUser()
        {
            return View();
        }



        public ActionResult GestionUser()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/users/";
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "findall").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.users = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.User>>().Result;
            }
            else
            {
                ViewBag.users = "erreur";
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {

            baseAddress = "http://localhost:9293/SpringMVC/servlet/users/";

            //HTTP POST
            var putTask = httpClient.PutAsJsonAsync<User>(baseAddress + "update", user);
            putTask.Wait();

            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionUser");
            }
            return View();

        }
        public ActionResult EditUser()
        {
            return View();
        }

        public ActionResult DeleteUser(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteUser(int id, FormCollection collection)
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/users/";
            //HTTP POST
            var putTask = httpClient.DeleteAsync(baseAddress + "delete/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionUser");
            }
            System.Diagnostics.Debug.WriteLine("entered here" + result);
            return View();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
