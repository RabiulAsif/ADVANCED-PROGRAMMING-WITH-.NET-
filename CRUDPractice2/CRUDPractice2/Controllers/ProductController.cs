using CRUDPractice2.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YourProjectName.Controllers
{
    public class ProductController : Controller
    {
        ProductDBEntities db = new ProductDBEntities();
        public ActionResult Index()
        {
            var data = db.Products.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = db.Products.Find(id);
            ViewBag.Categories = db.Categories.ToList();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var p = db.Products.Find(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(Product p)
        {
            var obj = db.Products.Find(p.Id);
            db.Products.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
