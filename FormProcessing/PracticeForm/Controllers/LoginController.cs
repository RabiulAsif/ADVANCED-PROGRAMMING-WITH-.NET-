using PracticeForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeForm.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            var name = Request["Username"];
            var log = new Login();
            return View(log);
        }
        [HttpPost]
        public ActionResult Index(Login log)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Home", "Index");
            }
            return View(log);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Registration(Student s)
        {
            if (ModelState.IsValid)
            {
                TempData["Msg"] = "Registration Successfull!";
                return RedirectToAction("Index");
            }
            return View(s);

        }
    }
}