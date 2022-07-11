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
            ModelState.Clear();
            var model = repo.StudentDetails();
            return View(model);
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
                return RedirectToAction("Index");
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var model = repo.StudentDetails().Find(x => x.id == id);
            model.genders = repo.GetGenders();
            return PartialView("Edit",model);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Student student)
        {
            try
            {
                // TODO: Add update logic here
                repo.UpdateStudent(student);    

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                if (repo.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student details deleted successfully";

                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool MultipleDelete(int[] multidelete)
        {
            try
            {
                var x = repo.MultipleDelete(multidelete);

                return x;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
