using Patient_Demographics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Patient_Demographics.Areas
{
    public class PatientController : Controller
    {
        public List<Patient> Patients { get; set; } = new List<Patient>();
        // GET: Patient
        public ActionResult Index()
        {
            List<Patient> patients = null;
            ViewBag.Title = "Home Page";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63971/api/");
                //HTTP GET
                var responseTask = client.GetAsync("values");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Patient>>();
                    readTask.Wait();

                    patients = readTask.Result;
                }
                else
                {


                    patients = new List<Patient>();
                }
            }
            return View(patients);
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:63971/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("values", patient);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return View(patient);
                
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Patient/Edit/5
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

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patient/Delete/5
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
