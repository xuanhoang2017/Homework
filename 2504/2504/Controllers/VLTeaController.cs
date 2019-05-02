using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2504.Controllers;
using _2504.Models;
using System.Transactions;

namespace _2504.Controllers
{
    public class VLTeaController : Controller
    {
        CS4PEEntities db = new CS4PEEntities();
        public ActionResult Index()
        {
            var model = db.BubleTeas;
            return View(model.ToList());
        }
         public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(BubleTea model)
         {
             ValidateBubleTea(model);
             if (ModelState.IsValid)
             {
                 db.BubleTeas.Add(model);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             else return View(model);
         }
        private void ValidateBubleTea(BubleTea model)
        {
            if (model.Price <= 0)
                ModelState.AddModelError("Price", Resource1.PRICE_LESS_0);
        }
        public ActionResult Delete(int id)
        {
            var model = db.BubleTeas.Find(id);
            if (model == null)
                return HttpNotFound();
            db.BubleTeas.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var model = db.BubleTeas.Find(id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(BubleTea model)
        {
            ValidateBubleTea(model);
            if(ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


      
    }
    
}