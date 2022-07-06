using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollegeCRUD_ADO_.Models.Repository;
using CollegeCRUD_ADO_.Models;

namespace CollegeCRUD_ADO_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        StudentRepository repo = null;
        
        public  HomeController()
        {
            repo = new StudentRepository(); 
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            var model = new Student();
            model.genders = repo.GetGenders();
            return PartialView(model);  
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (repo.AddStudent(student))
                    {
                        ViewBag.success = "Employee added successfully";
                    }
                }
                return View("Index");
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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
