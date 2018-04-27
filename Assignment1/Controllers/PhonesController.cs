using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class PhonesController : Controller
    {
        //Collection of Phones
        private List<PhoneBase> Phones;

        //add a constructor and initialize the collection
        public PhonesController()
        {
            Phones = new List<PhoneBase> ();

            var iphone = new PhoneBase();

            iphone.Id = 1;
            iphone.PhoneName = "iPhone 8";
            iphone.Manufacturer = "Apple";
            iphone.DateReleased = new DateTime(2017, 9, 1);
            iphone.MSRP = 849;
            iphone.ScreenSize = 5.5;
            Phones.Add(iphone);

            var galaxy = new PhoneBase();

            galaxy.Id = 2;
            galaxy.PhoneName = "Galaxy Note 8";
            galaxy.Manufacturer = "Samsung";
            galaxy.DateReleased = new DateTime(2017, 8, 1);
            galaxy.MSRP = 749;
            galaxy.ScreenSize = 5.7;
            Phones.Add(galaxy);

            var microsoft = new PhoneBase();

            microsoft.Id = 3;
            microsoft.PhoneName = "Surface Phone";
            microsoft.Manufacturer = "Microsoft";
            microsoft.DateReleased = new DateTime(2017, 3, 1);
            microsoft.MSRP = 800;
            microsoft.ScreenSize = 5.5;
            Phones.Add(microsoft);
        }

        //Get: Phones
         public ActionResult Index()
        {
            return View(Phones);
        }

        // GET: Phones/Details/5
        public ActionResult Details(int Id)
        {
            return View(Phones[Id-1]);
        }

        // GET: Phones/Create
        public ActionResult Create()
        {
            return View(new PhoneBase());
        }

        // POST: Phones/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var newItem = new PhoneBase();
                newItem.Id = Phones.Count + 1;
                newItem.PhoneName = collection["PhoneNumber"];
                newItem.Manufacturer = collection["Manufacturer"];
                newItem.DateReleased = Convert.ToDateTime(collection["DateReleased"]);
                int msrp;
                double ss;
                bool isNumber;

                // MSRP
                isNumber = Int32.TryParse(collection["MSRP"], out msrp);
                newItem.MSRP = msrp;

                // Screen Size
                isNumber = double.TryParse(collection["ScreenSize"], out ss);
                newItem.ScreenSize = ss;

                // Add to the collection
                Phones.Add(newItem);
                return RedirectToAction("Details", newItem);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return View("Your Input is correct but we are unable to store the value this time. sorry for the inconvenient.");
                throw (e);
            }
        }
    }
}
