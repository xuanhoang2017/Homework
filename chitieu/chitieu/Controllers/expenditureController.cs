using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using chitieu.Models;

namespace chitieu.Controllers
{
    public class expenditureController : Controller
    {
        private AnchoiEntities db = new AnchoiEntities();

        // GET: /expenditure/
//        public ActionResult Index()
//        {
//            return View(db.expenditures.ToList());
//        }

//        // GET: /expenditure/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            expenditure expenditure = db.expenditures.Find(id);
//            if (expenditure == null)
//            {
//                return HttpNotFound();
//            }
//            return View(expenditure);
//        }

//        // GET: /expenditure/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: /expenditure/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include="id,datetime,amount,note")] expenditure expenditure)
//        {
//            if (ModelState.IsValid)
//            {
//                db.expenditures.Add(expenditure);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(expenditure);
//        }

//        // GET: /expenditure/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            expenditure expenditure = db.expenditures.Find(id);
//            if (expenditure == null)
//            {
//                return HttpNotFound();
//            }
//            return View(expenditure);
//        }

//        // POST: /expenditure/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include="id,datetime,amount,note")] expenditure expenditure)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(expenditure).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(expenditure);
//        }

//        // GET: /expenditure/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            expenditure expenditure = db.expenditures.Find(id);
//            if (expenditure == null)
//            {
//                return HttpNotFound();
//            }
//            return View(expenditure);
//        }

//        // POST: /expenditure/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            expenditure expenditure = db.expenditures.Find(id);
//            db.expenditures.Remove(expenditure);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
        public ActionResult Index()
        {
            return View(db.expenditures.ToList());
        }

        // GET: /ChiTieu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expenditure expenditure = db.expenditures.Find(id);
            if (expenditure == null)
            {
                return HttpNotFound();
            }
            return View(expenditure);
        }

        // GET: /ChiTieu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ChiTieu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(expenditure model)
        {
            ValidateExpenditure(model);
            if (ModelState.IsValid)
            {
                model.datetime = DateTime.Today;
                db.expenditures.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public void ValidateExpenditure(expenditure model)
        {
            if (model.amount <= 0)
            {
                ModelState.AddModelError("amount", "Số tiền quá ít");
            }
        }

        // GET: /ChiTieu/Edit/5
        public ActionResult Edit(int? id)
        {
            expenditure expenditure = db.expenditures.Find(id);
            if (expenditure == null)
            {
                return HttpNotFound();
            }
            return View(expenditure);
        }

        // POST: /ChiTieu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "amount,id,note,datetime")] expenditure model)
        {
            ValidateExpenditure(model);
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /ChiTieu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expenditure expenditure = db.expenditures.Find(id);
            if (expenditure == null)
            {
                return HttpNotFound();
            }
            return View(expenditure);
        }

        // POST: /ChiTieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            expenditure expenditure = db.expenditures.Find(id);
            db.expenditures.Remove(expenditure);
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

