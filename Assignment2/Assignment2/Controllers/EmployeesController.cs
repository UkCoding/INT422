using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class EmployeesController : Controller
    {
        private Manager m = new Manager();

        // GET: Employees
        public ActionResult Index()
        {

            var o = m.EmployeeGetAll();
            return View(o);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.EmployeeGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }

        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            // m.EmployeeAdd();
            return View(new EmployeeAdd());
        }

        /*
        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(EmployeeAdd newItem)
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
        */


        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(EmployeeAdd newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }
            // Process the input
            var addedItem = m.EmployeeAdd(newItem);
            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.EmployeeId });
            }
        }


        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employees/Edit/5
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

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employees/Delete/5
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
