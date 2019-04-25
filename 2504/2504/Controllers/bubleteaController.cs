using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2504.Models;

namespace _2504.Controllers
{
    public class bubleteaController : Controller
    {
        private CS4PEEntities db = new CS4PEEntities();

        // GET: /bubletea/
        public ActionResult Index()
        {
            return View(db.BubleTeas.ToList());
        }

        // GET: /bubletea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BubleTea bubletea = db.BubleTeas.Find(id);
            if (bubletea == null)
            {
                return HttpNotFound();
            }
            return View(bubletea);
        }

        // GET: /bubletea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /bubletea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Name,Price,Topping")] BubleTea bubletea)
        {
            if (ModelState.IsValid)
            {
                db.BubleTeas.Add(bubletea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bubletea);
        }

        // GET: /bubletea/Edit/5
        public ActionResult Edit(int? id)
        {
            var model = db.BubleTeas.Find(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View("Edit", model);
        }

        // POST: /bubletea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Name,Price,Topping")] BubleTea bubletea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bubletea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bubletea);
        }

        // GET: /bubletea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BubleTea bubletea = db.BubleTeas.Find(id);
            if (bubletea == null)
            {
                return HttpNotFound();
            }
            return View(bubletea);
        }

        // POST: /bubletea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BubleTea bubletea = db.BubleTeas.Find(id);
            db.BubleTeas.Remove(bubletea);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
