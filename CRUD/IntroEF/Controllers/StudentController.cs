using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class StudentController : Controller
    {
        IntroEFEntities db = new IntroEFEntities();
        // GET: Student

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
            TempData["Msg"] = "Student " + s.Name + " Created";
            return RedirectToAction("List");
        }
        public ActionResult List(string search)
        {
            if (search != null)
            {
                var filter = (from s in db.Students
                              where s.Name.Contains(search)
                              select s).ToList();
                return View(filter);
            }
            var data = db.Students.ToList();
            return View(data);
        }

        public ActionResult Details(int id)
        {
            var data = db.Students.Find(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var data = db.Students.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Update(Student s)
        {
            var dbObj = db.Students.Find(s.Id);
            db.Entry(dbObj).CurrentValues.SetValues(s);
            db.SaveChanges();
            TempData["Msg"] = "Data Updated!";
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Students.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            var data = db.Students.Find(s.Id);
            db.Students.Remove(data);
            db.SaveChanges();

            TempData["Msg"] = "Data Deleted!";
            return RedirectToAction("List");
        }

    }
}